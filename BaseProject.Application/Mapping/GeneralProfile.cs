using AutoMapper;
using BaseProject.Domain.Entities.Auth;
using BaseProject.Domain.Models.Users;

namespace BaseProject.Application.Mapping
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}