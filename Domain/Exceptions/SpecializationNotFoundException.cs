using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class SpecializationNotFoundException : NotFoundException
    {
        public SpecializationNotFoundException(int specializationId)
            : base($"The specialization with the id {specializationId} was not found.")
        {
        }
    }
}
