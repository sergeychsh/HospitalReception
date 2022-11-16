using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public int CabinetNumber { get; set; }
        public string SpecializationName { get; set; }
        public int SiteNumber { get; set; }
    }
}
