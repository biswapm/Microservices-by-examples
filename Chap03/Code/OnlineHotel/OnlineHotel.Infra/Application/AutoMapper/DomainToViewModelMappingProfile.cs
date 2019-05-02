using AutoMapper;
using OnlineHotel.Infra.Application.ViewModels;
using OnlineHotel.Infra.Domain.Models;

namespace OnlineHotel.Infra.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}
