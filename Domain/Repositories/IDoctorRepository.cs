using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IDoctorRepository
    {
        Task<PagedList<Doctor>> GetAllAsync(DoctorParameters doctorParameters, CancellationToken cancellationToken = default);
        Task<Doctor> GetByIdAsync(int doctorId, CancellationToken cancellationToken = default);
        void Insert(Doctor doctor);
        void Update(Doctor doctor);
        void Remove(Doctor doctor);
    }
}
