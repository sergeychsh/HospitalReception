using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class DoctorForCreationDto
    {
        [Required(ErrorMessage = "FIO is required")]
        public string FIO { get; set; }

        [Required(ErrorMessage = "CabinetId is required")]
        public int CabinetId { get; set; }

        [Required(ErrorMessage = "SpecializationId is required")]
        public int SpecializationId { get; set; }

        public int SiteId { get; set; }
    }
}
