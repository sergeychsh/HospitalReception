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
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasData(new Doctor
            {
                Id = 1,
                FIO = "Лемешова А.Н.",
                Cabinet = null,
                Specialization = null,
                Site = null
            }, new Doctor
            {
                Id = 2,
                FIO = "Денисова Е.В",
                Cabinet = null,
                Specialization = null,
                Site = null
            }, new Doctor
            {
                Id = 3,
                FIO = "Ситникова О.В.",
                Cabinet = null,
                Specialization = null,
                Site = null
            }, new Doctor
            {
                Id = 4,
                FIO = "Муравьёва С. А.",
                Cabinet = null,
                Specialization = null,
                Site = null
            });
        }
    }
}
