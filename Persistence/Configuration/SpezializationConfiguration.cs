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
    public class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
    {
        public void Configure(EntityTypeBuilder<Specialization> builder)
        {
            builder.HasData(new Specialization
            {
                Id = 1,
                Name = "Терапевт"
            }, new Specialization
            {
                Id = 2,
                Name = "Аллерголог"
            }, new Specialization
            {
                Id = 3,
                Name = "Офтальмолог"
            }, new Specialization
            {
                Id = 4,
                Name = "Хирург"
            }, new Specialization
            {
                Id = 5,
                Name = "Стоматолог"
            }, new Specialization
            {
                Id = 6,
                Name = "Педиатр"
            });
        }
    }
}
