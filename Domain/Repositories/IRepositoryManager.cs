using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IRepositoryManager
    {
        IPatientRepository PatientRepository { get; }
        IDoctorRepository DoctorRepository { get; }
        ISiteRepository SiteRepository { get; }
        ISpecializationRepository SpecializationRepository { get; }
        ICabinetRepository CabinetRepository { get; }
        IUnitOfWork UnitOfWork { get; }
    }
}
