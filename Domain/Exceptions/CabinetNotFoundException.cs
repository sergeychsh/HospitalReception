using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class CabinetNotFoundException : NotFoundException
    {
        public CabinetNotFoundException(int cabinetId)
            : base($"The cabinet with the id {cabinetId} was not found.")
        {
        }
    }
}
