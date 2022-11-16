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
    [Route("api/doctors")]
    public class DoctorsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public DoctorsController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        // GET: api/doctors
        [HttpGet]
        public async Task<IActionResult> GetDoctors([FromQuery] DoctorParameters doctorParameters, CancellationToken cancellationToken)
        {
            var doctors = await _serviceManager.DoctorService.GetAllAsync(doctorParameters, cancellationToken);

            return Ok(doctors);
        }

        // GET: api/doctors/1
        [HttpGet("{id}", Name = "DoctorById")]
        public async Task<IActionResult> GetDoctorById(int id, CancellationToken cancellationToken)
        {
            var doctorDto = await _serviceManager.DoctorService.GetByIdAsync(id, cancellationToken);

            return Ok(doctorDto);
        }

        // POST: api/doctors
        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] DoctorForCreationDto doctorForCreationDto, CancellationToken cancellationToken)
        {
            var doctorDto = await _serviceManager.DoctorService.CreateAsync(doctorForCreationDto, cancellationToken);

            return CreatedAtAction(nameof(GetDoctorById), new { id = doctorDto.Id }, doctorDto);
        }

        // PUT: api/doctors/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(int id, [FromBody] DoctorForCreationDto doctorForCreationDto, CancellationToken cancellationToken)
        {
            await _serviceManager.DoctorService.UpdateAsync(id, doctorForCreationDto, cancellationToken);

            return NoContent();
        }

        // DELETE: api/doctors/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id, CancellationToken cancellationToken)
        {
            await _serviceManager.DoctorService.DeleteAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
