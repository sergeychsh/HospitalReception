using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class DoctorDetailDto
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public int CabinetId { get; set; }
        public int SpecializationId { get; set; }
        public int SiteId { get; set; }
    }
}
