using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class SpecializationRepository : ISpecializationRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public SpecializationRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public async Task<Specialization> GetByIdAsync(int specializationId, CancellationToken cancellationToken = default) =>
            await _dbContext.Specializations.FirstOrDefaultAsync(s => s.Id == specializationId, cancellationToken);
    }
}
