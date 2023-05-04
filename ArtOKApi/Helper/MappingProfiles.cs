using ArtOKApi.Dto;
using ArtOKApi.Models;
using AutoMapper;

namespace ArtOKApi.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();
        }
    }
}
