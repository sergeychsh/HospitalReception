using AutoMapper;
using Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    internal sealed class DoctorService : IDoctorService
    {
        private readonly IRepositoryManager _repositoryManager;
        private IMapper _mapper;

        public DoctorService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DoctorDto>> GetAllAsync(DoctorParameters doctorParameters, CancellationToken cancellationToken = default)
        {
            var doctors = await _repositoryManager.DoctorRepository.GetAllAsync(doctorParameters, cancellationToken);

            var doctorsDto = _mapper.Map<IEnumerable<DoctorDto>>(doctors);

            return doctorsDto;
        }

        public async Task<DoctorDetailDto> GetByIdAsync(int doctorId, CancellationToken cancellationToken = default)
        {
            var doctor = await _repositoryManager.DoctorRepository.GetByIdAsync(doctorId, cancellationToken);

            if (doctor is null)
            {
                throw new DoctorNotFoundException(doctorId);
            }

            var doctorDetailDto = _mapper.Map<DoctorDetailDto>(doctor);

            return doctorDetailDto;
        }

        public async Task<DoctorDetailDto> CreateAsync(DoctorForCreationDto doctorForCreationDto, CancellationToken cancellationToken = default)
        {
            var doctor = _mapper.Map<Doctor>(doctorForCreationDto);

            doctor.Site = await GetSiteById(doctorForCreationDto.SiteId, cancellationToken);
            doctor.Specialization = await GetSpecializationById(doctorForCreationDto.SpecializationId, cancellationToken);
            doctor.Cabinet = await GetCabinetById(doctorForCreationDto.CabinetId, cancellationToken);

            _repositoryManager.DoctorRepository.Insert(doctor);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<DoctorDetailDto>(doctor);
        }

        public async Task UpdateAsync(int doctorId, DoctorForCreationDto doctorForCreationDto, CancellationToken cancellationToken = default)
        {
            var doctor = await _repositoryManager.DoctorRepository.GetByIdAsync(doctorId, cancellationToken);

            if (doctor is null)
            {
                throw new DoctorNotFoundException(doctorId);
            }

            doctor.FIO = doctorForCreationDto.FIO;
            doctor.Site = await GetSiteById(doctorForCreationDto.SiteId, cancellationToken);
            doctor.Specialization = await GetSpecializationById(doctorForCreationDto.SpecializationId, cancellationToken);
            doctor.Cabinet = await GetCabinetById(doctorForCreationDto.CabinetId, cancellationToken);

            _repositoryManager.DoctorRepository.Update(doctor);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int doctorId, CancellationToken cancellationToken = default)
        {
            var doctor = await _repositoryManager.DoctorRepository.GetByIdAsync(doctorId, cancellationToken);

            if (doctor is null)
            {
                throw new DoctorNotFoundException(doctorId);
            }

            _repositoryManager.DoctorRepository.Remove(doctor);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        private async Task<Site> GetSiteById(int siteId, CancellationToken cancellationToken = default)
        {
            if (siteId == 0)
                return null;

            var site = await _repositoryManager.SiteRepository.GetByIdAsync(siteId, cancellationToken);

            if (site is null)
            {
                throw new SiteNotFoundException(siteId);
            }

            return site;
        }

        private async Task<Specialization> GetSpecializationById(int specializationId, CancellationToken cancellationToken = default)
        {
            var specialization = await _repositoryManager.SpecializationRepository.GetByIdAsync(specializationId, cancellationToken);

            if (specialization is null)
            {
                throw new SpecializationNotFoundException(specializationId);
            }

            return specialization;
        }

        private async Task<Cabinet> GetCabinetById(int cabinetId, CancellationToken cancellationToken = default)
        {
            var cabinet = await _repositoryManager.CabinetRepository.GetByIdAsync(cabinetId, cancellationToken);

            if (cabinet is null)
            {
                throw new CabinetNotFoundException(cabinetId);
            }

            return cabinet;
        }
    }
}
