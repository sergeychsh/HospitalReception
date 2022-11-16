using System;
using AutoMapper;
using Domain.Repositories;
using Services.Abstractions;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IPatientService> _lazyPatientService;
        private readonly Lazy<IDoctorService> _lazyDoctorService;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _lazyPatientService = new Lazy<IPatientService>(() => new PatientService(repositoryManager, mapper));
            _lazyDoctorService = new Lazy<IDoctorService>(() => new DoctorService(repositoryManager, mapper));
        }

        public IPatientService PatientService => _lazyPatientService.Value;
        public IDoctorService DoctorService => _lazyDoctorService.Value;
    }
}
