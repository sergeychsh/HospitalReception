using AutoMapper;
using Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalReception
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, PatientDto>().IncludeMembers(p => p.Site);
            CreateMap<Site, PatientDto>();
            CreateMap<Patient, PatientDetailDto>().IncludeMembers(p => p.Site);
            CreateMap<Site, PatientDetailDto>();
            CreateMap<PatientForCreationDto, Patient>();

            CreateMap<Doctor, DoctorDto>().IncludeMembers(p => p.Site).IncludeMembers(p => p.Cabinet).IncludeMembers(p => p.Specialization);
            CreateMap<Site, DoctorDto>();
            CreateMap<Cabinet, DoctorDto>();
            CreateMap<Specialization, DoctorDto>();
            CreateMap<Doctor, DoctorDetailDto>().IncludeMembers(p => p.Site).IncludeMembers(p => p.Cabinet).IncludeMembers(p => p.Specialization);
            CreateMap<Site, DoctorDetailDto>();
            CreateMap<Cabinet, DoctorDetailDto>();
            CreateMap<Specialization, DoctorDetailDto>();
            CreateMap<DoctorForCreationDto, Doctor>();
        }
    }
}
