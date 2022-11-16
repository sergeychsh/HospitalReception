using Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorDto>> GetAllAsync(DoctorParameters doctorParameters, CancellationToken cancellationToken = default);

        Task<DoctorDetailDto> GetByIdAsync(int doctorId, CancellationToken cancellationToken = default);

        Task<DoctorDetailDto> CreateAsync(DoctorForCreationDto doctorForCreationDto, CancellationToken cancellationToken = default);

        Task UpdateAsync(int doctorId, DoctorForCreationDto doctorForCreationDto, CancellationToken cancellationToken = default);

        Task DeleteAsync(int doctorId, CancellationToken cancellationToken = default);
    }
}
