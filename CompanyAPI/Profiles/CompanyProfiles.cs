using AutoMapper;
using CompanyAPI.Dtos;
using CompanyAPI.Models;

namespace CompanyAPI.Profiles
{
    public class CompanyProfiles : Profile
    {
        public CompanyProfiles() 
        {
            CreateMap<CompanyCreatedDtoI, Company>();

            CreateMap<Company, CompanyReadDto>();

            CreateMap<CompanyUpdateDto, Company>();

        }
    }
}
