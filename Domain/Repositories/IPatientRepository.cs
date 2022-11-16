using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IPatientRepository
    {
        Task<PagedList<Patient>> GetAllAsync(PatientParameters patientParameters, CancellationToken cancellationToken = default);
        Task<Patient> GetByIdAsync(int patientId, CancellationToken cancellationToken = default);
        void Insert(Patient patient);
        void Update(Patient patient);
        void Remove(Patient patient);
    }
}
