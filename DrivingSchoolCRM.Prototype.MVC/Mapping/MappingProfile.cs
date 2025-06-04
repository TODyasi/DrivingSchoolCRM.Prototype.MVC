using AutoMapper;
using DrivingSchoolCRM.Prototype.MVC.Models.User;
using DrivingSchoolCRM.Prototype.MVC.Models.User.Dtos;

namespace DrivingSchoolCRM.Prototype.MVC.Mapping
{
    public class MappingProfile : Profile
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingProfile = new MapperConfiguration(config =>
            {
                config.CreateMap<UserDto, UserModel>();
                config.CreateMap<UserModel, UserDto>();
            });
            return mappingProfile;
        }
    }
}
