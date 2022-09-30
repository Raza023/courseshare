using webapp.Models.ViewModels;
using webapp.Models;
using AutoMapper;                        //must have to add this line

namespace webapp.MappingConfiguration
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Users, UserViewModel>();
        }
    }
}