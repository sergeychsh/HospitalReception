using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class SiteNotFoundException : NotFoundException
    {
        public SiteNotFoundException(int siteId)
            : base($"The site with the id {siteId} was not found.")
        {
        }
    }
}
