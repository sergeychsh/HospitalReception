using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class PatientNotFoundException : NotFoundException
    {
        public PatientNotFoundException(int patientId)
            : base($"The patient with the id {patientId} was not found.")
        {
        }
    }
}
