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
    internal sealed class PatientService : IPatientService
    {
        private readonly IRepositoryManager _repositoryManager;
        private IMapper _mapper;

        public PatientService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PatientDto>> GetAllAsync(PatientParameters patientParameters, CancellationToken cancellationToken = default)
        {
            var patients = await _repositoryManager.PatientRepository.GetAllAsync(patientParameters, cancellationToken);

            var patientsDto = _mapper.Map<IEnumerable<PatientDto>>(patients);

            return patientsDto;
        }

        public async Task<PatientDetailDto> GetByIdAsync(int patientId, CancellationToken cancellationToken = default)
        {
            var patient = await _repositoryManager.PatientRepository.GetByIdAsync(patientId, cancellationToken);

            if (patient is null)
            {
                throw new PatientNotFoundException(patientId);
            }

            var patientDetailDto = _mapper.Map<PatientDetailDto>(patient);

            return patientDetailDto;
        }

        public async Task<PatientDetailDto> CreateAsync(PatientForCreationDto patientForCreationDto, CancellationToken cancellationToken = default)
        {
            var patient = _mapper.Map<Patient>(patientForCreationDto);

            patient.Site = await GetSiteById(patientForCreationDto.SiteId, cancellationToken);

            _repositoryManager.PatientRepository.Insert(patient);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<PatientDetailDto>(patient);
        }

        public async Task UpdateAsync(int patientId, PatientForCreationDto patientForCreationDto, CancellationToken cancellationToken = default)
        {
            var patient = await _repositoryManager.PatientRepository.GetByIdAsync(patientId, cancellationToken);

            if (patient is null)
            {
                throw new PatientNotFoundException(patientId);
            }

            patient.FirstName = patientForCreationDto.FirstName;
            patient.LastName = patientForCreationDto.LastName;
            patient.MiddleName = patientForCreationDto.MiddleName;
            patient.Address = patientForCreationDto.Address;
            patient.DateOfBirth = patientForCreationDto.DateOfBirth;
            patient.Gender = (Domain.Entities.Gender)patientForCreationDto.Gender;
            patient.Site = await GetSiteById(patientForCreationDto.SiteId, cancellationToken);

            _repositoryManager.PatientRepository.Update(patient);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int patientId, CancellationToken cancellationToken = default)
        {
            var patient = await _repositoryManager.PatientRepository.GetByIdAsync(patientId, cancellationToken);

            if (patient is null)
            {
                throw new PatientNotFoundException(patientId);
            }

            _repositoryManager.PatientRepository.Remove(patient);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        private async Task<Site> GetSiteById(int siteId, CancellationToken cancellationToken = default)
        {
            var site = await _repositoryManager.SiteRepository.GetByIdAsync(siteId, cancellationToken);

            if (site is null)
            {
                throw new SiteNotFoundException(siteId);
            }

            return site;
        }
    }
}
