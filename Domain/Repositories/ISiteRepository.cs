using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ISiteRepository
    {
        Task<Site> GetByIdAsync(int siteId, CancellationToken cancellationToken = default);
    }
}
