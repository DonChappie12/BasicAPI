using AutoMapper;
using BasicAPI.DTOs;
using BasicAPI.Models;

namespace BasicAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, User>();
            // Don't know if we need this
            CreateMap<User, UserDTO>();
        }
    }
}