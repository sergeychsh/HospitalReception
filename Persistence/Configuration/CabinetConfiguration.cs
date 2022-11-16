using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class CabinetConfiguration : IEntityTypeConfiguration<Cabinet>
    {
        public void Configure(EntityTypeBuilder<Cabinet> builder)
        {
            builder.HasData(new Cabinet
            {
                Id = 1,
                Number = 11
            }, new Cabinet
            {
                Id = 2,
                Number = 12
            }, new Cabinet
            {
                Id = 3,
                Number = 13
            }, new Cabinet
            {
                Id = 4,
                Number = 14
            }, new Cabinet
            {
                Id = 5,
                Number = 15
            }, new Cabinet
            {
                Id = 6,
                Number = 16
            });
        }
    }
}
