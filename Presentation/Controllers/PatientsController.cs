using System;
using System.Threading;
using System.Threading.Tasks;
using Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class PatientsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public PatientsController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        // GET: api/patients
        [HttpGet]
        public async Task<IActionResult> GetPatients([FromQuery] PatientParameters patientParameters, CancellationToken cancellationToken)
        {
            var patients = await _serviceManager.PatientService.GetAllAsync(patientParameters, cancellationToken);

            return Ok(patients);
        }

        // GET: api/patients/1
        [HttpGet("{id}", Name = "PatientById")]
        public async Task<IActionResult> GetPatientById(int id, CancellationToken cancellationToken)
        {
            var patientDto = await _serviceManager.PatientService.GetByIdAsync(id, cancellationToken);

            return Ok(patientDto);
        }

        // POST: api/patients
        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] PatientForCreationDto patientForCreationDto, CancellationToken cancellationToken)
        {
            var patientDto = await _serviceManager.PatientService.CreateAsync(patientForCreationDto, cancellationToken);

            return CreatedAtAction(nameof(GetPatientById), new { id = patientDto.Id }, patientDto);
        }

        // PUT: api/patients/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] PatientForCreationDto patientForCreationDto, CancellationToken cancellationToken)
        {
            await _serviceManager.PatientService.UpdateAsync(id, patientForCreationDto, cancellationToken);

            return NoContent();
        }

        // DELETE: api/patients/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id, CancellationToken cancellationToken)
        {
            await _serviceManager.PatientService.DeleteAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
