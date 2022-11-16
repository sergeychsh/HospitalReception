using System;
using Domain.Entities;
using Domain.Helpers;
using Domain.Repositories;

namespace Persistence.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IPatientRepository> _lazyPatientRepository;
        private readonly Lazy<IDoctorRepository> _lazyDoctorRepository;
        private readonly Lazy<ISiteRepository> _lazySiteRepository;
        private readonly Lazy<ISpecializationRepository> _lazySpecializationRepository;
        private readonly Lazy<ICabinetRepository> _lazyCabinetRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public RepositoryManager(RepositoryDbContext dbContext, ISortHelper<Patient> patientSortHelper, ISortHelper<Doctor> doctorSortHelper)
        {
            _lazyPatientRepository = new Lazy<IPatientRepository>(() => new PatientRepository(dbContext, patientSortHelper));
            _lazyDoctorRepository = new Lazy<IDoctorRepository>(() => new DoctorRepository(dbContext, doctorSortHelper));
            _lazySiteRepository = new Lazy<ISiteRepository>(() => new SiteRepository(dbContext));
            _lazySpecializationRepository = new Lazy<ISpecializationRepository>(() => new SpecializationRepository(dbContext));
            _lazyCabinetRepository = new Lazy<ICabinetRepository>(() => new CabinetRepository(dbContext));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
        }

        public IPatientRepository PatientRepository => _lazyPatientRepository.Value;
        public IDoctorRepository DoctorRepository => _lazyDoctorRepository.Value;
        public ISiteRepository SiteRepository => _lazySiteRepository.Value;
        public ISpecializationRepository SpecializationRepository => _lazySpecializationRepository.Value;
        public ICabinetRepository CabinetRepository => _lazyCabinetRepository.Value;
        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value; 
    }
}
