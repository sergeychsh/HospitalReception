using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class DoctorNotFoundException : NotFoundException
    {
        public DoctorNotFoundException(int doctorId)
            : base($"The doctor with the id {doctorId} was not found.")
        {
        }
    }
}
