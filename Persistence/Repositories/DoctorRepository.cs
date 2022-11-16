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
    internal sealed class DoctorRepository : IDoctorRepository
    {
        private readonly RepositoryDbContext _dbContext;
        private ISortHelper<Doctor> _sortHelper;

        public DoctorRepository(RepositoryDbContext dbContext, ISortHelper<Doctor> sortHelper)
        {
            _dbContext = dbContext;
            _sortHelper = sortHelper;
        }

        public async Task<PagedList<Doctor>> GetAllAsync(DoctorParameters doctorParameters, CancellationToken cancellationToken = default)
        {
            var doctors = await _dbContext.Doctors.Include(p => p.Site)
                                                  .Include(p => p.Specialization)
                                                  .Include(p => p.Cabinet).ToListAsync(cancellationToken);

            var sortedDoctors = _sortHelper.ApplySort(doctors.AsQueryable(), doctorParameters.OrderBy).ToList<Doctor>();

            var pagedDoctor = PagedList<Doctor>.ToPagedList(sortedDoctors, doctorParameters.PageNumber, doctorParameters.PageSize);

            return pagedDoctor;
        }

        public async Task<Doctor> GetByIdAsync(int doctorId, CancellationToken cancellationToken = default) =>
            await _dbContext.Doctors.Include(p => p.Site)
                                    .Include(p => p.Specialization)
                                    .Include(p => p.Cabinet).FirstOrDefaultAsync(p => p.Id == doctorId, cancellationToken);

        public void Insert(Doctor doctor) => _dbContext.Doctors.Add(doctor);

        public void Update(Doctor doctor) => _dbContext.Doctors.Update(doctor);

        public void Remove(Doctor doctor) => _dbContext.Doctors.Remove(doctor);
    }
}
