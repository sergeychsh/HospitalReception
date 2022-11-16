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
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasData(new Patient
            {
                Id = 1,
                FirstName = "Иван",
                LastName = "Иванов",
                MiddleName = "Иванович",
                Address = "Улица Чехова, 1",
                DateOfBirth = RandomDay(),
                Gender = Gender.Male,
                Site = null
            }, new Patient
            {
                Id = 2,
                FirstName = "Петр",
                LastName = "Петров",
                MiddleName = "Петрович",
                Address = "Улица Ломоносова, 61",
                DateOfBirth = RandomDay(),
                Gender = Gender.Male,
                Site = null
            }, new Patient
            {
                Id = 3,
                FirstName = "Эдуард",
                LastName = "Харитонов",
                MiddleName = "Михайлович",
                Address = "Улица Чехова, 2",
                DateOfBirth = RandomDay(),
                Gender = Gender.Male,
                Site = null
            }, new Patient
            {
                Id = 4,
                FirstName = "Вячеслав",
                LastName = "Рыбаков",
                MiddleName = "Андреевич",
                Address = "Улица Чехова, 3",
                DateOfBirth = RandomDay(),
                Gender = Gender.Male,
                Site = null
            }, new Patient
            {
                Id = 5,
                FirstName = "Иван",
                LastName = "Селиванов",
                MiddleName = "Антонович",
                Address = "Улица Ломоносова, 59",
                DateOfBirth = RandomDay(),
                Gender = Gender.Male,
                Site = null
            }, new Patient
            {
                Id = 6,
                FirstName = "Семен",
                LastName = "Степанов",
                MiddleName = "Иванович",
                Address = "Улица Чехова, 1",
                DateOfBirth = RandomDay(),
                Gender = Gender.Male,
                Site = null
            }, new Patient
            {
                Id = 7,
                FirstName = "Антон",
                LastName = "Воронов",
                MiddleName = "Петрович",
                Address = "Улица Чехова, 2",
                DateOfBirth = RandomDay(),
                Gender = Gender.Male,
                Site = null
            }, new Patient
            {
                Id = 8,
                FirstName = "Михаил",
                LastName = "Свиридов",
                MiddleName = "Александрович",
                Address = "Улица Ломоносова, 59",
                DateOfBirth = RandomDay(),
                Gender = Gender.Male,
                Site = null
            });
        }

        private DateTime RandomDay()
        {
            DateTime start = new DateTime(1990, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(new Random().Next(range));
        }
    }
}
