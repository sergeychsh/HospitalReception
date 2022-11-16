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
    internal sealed class CabinetRepository : ICabinetRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public CabinetRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public async Task<Cabinet> GetByIdAsync(int cabinetId, CancellationToken cancellationToken = default) =>
            await _dbContext.Cabinets.FirstOrDefaultAsync(s => s.Id == cabinetId, cancellationToken);
    }
}
