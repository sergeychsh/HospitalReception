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
    internal sealed class SiteRepository : ISiteRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public SiteRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public async Task<Site> GetByIdAsync(int siteId, CancellationToken cancellationToken = default) =>
            await _dbContext.Sites.FirstOrDefaultAsync(s => s.Id == siteId, cancellationToken);
    }
}
