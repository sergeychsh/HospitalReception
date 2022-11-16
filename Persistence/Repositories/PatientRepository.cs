using Domain.Entities;
using Domain.Helpers;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class PatientRepository : IPatientRepository
    {
        private readonly RepositoryDbContext _dbContext;
        private ISortHelper<Patient> _sortHelper;

        public PatientRepository(RepositoryDbContext dbContext, ISortHelper<Patient> sortHelper)
        {
            _dbContext = dbContext;
            _sortHelper = sortHelper;
        }

        public async Task<PagedList<Patient>> GetAllAsync(PatientParameters patientParameters, CancellationToken cancellationToken = default)
        {
            var patients = await _dbContext.Patients.Include(p => p.Site).ToListAsync(cancellationToken);

            var sortedPatients = _sortHelper.ApplySort(patients.AsQueryable(), patientParameters.OrderBy).ToList<Patient>();

            var pagedPatient = PagedList<Patient>.ToPagedList(sortedPatients, patientParameters.PageNumber, patientParameters.PageSize);

            return pagedPatient;
        }

        public async Task<Patient> GetByIdAsync(int patientId, CancellationToken cancellationToken = default) =>
            await _dbContext.Patients.Include(p => p.Site).FirstOrDefaultAsync(p => p.Id == patientId, cancellationToken);

        public void Insert(Patient patient) => _dbContext.Patients.Add(patient);

        public void Update(Patient patient) => _dbContext.Patients.Update(patient);

        public void Remove(Patient patient) => _dbContext.Patients.Remove(patient);
    }
}
