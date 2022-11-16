﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICabinetRepository
    {
        Task<Cabinet> GetByIdAsync(int cabinetId, CancellationToken cancellationToken = default);
    }
}
