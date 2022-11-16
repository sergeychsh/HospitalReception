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
    public interface IPatientService
    {
        Task<IEnumerable<PatientDto>> GetAllAsync(PatientParameters patientParameters, CancellationToken cancellationToken = default);

        Task<PatientDetailDto> GetByIdAsync(int patientId, CancellationToken cancellationToken = default);

        Task<PatientDetailDto> CreateAsync(PatientForCreationDto patientForCreationDto, CancellationToken cancellationToken = default);

        Task UpdateAsync(int patientId, PatientForCreationDto patientForCreationDto, CancellationToken cancellationToken = default);

        Task DeleteAsync(int patientId, CancellationToken cancellationToken = default);
    }
}
