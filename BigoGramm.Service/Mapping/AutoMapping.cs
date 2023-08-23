using AutoMapper;
using BigoGramm.Domain.Entities;
using BigoGramm.Service.DTOs.Chat;
using BigoGramm.Service.DTOs.Comment;
using BigoGramm.Service.DTOs.Post;
using BigoGramm.Service.DTOs.User;

namespace BigoGramm.Service.Mapping;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<UserCreationDto,User>().ReverseMap();
        CreateMap<UserUpdateDto, User>().ReverseMap();
        CreateMap<UserResultDto, User>().ReverseMap();

        CreateMap<PostCreationDto, Post>().ReverseMap();
        CreateMap<PostResultDto, Post>().ReverseMap();
        CreateMap<PostUpdateDto, Post>().ReverseMap();

        CreateMap<CommentCreationDto, Comment>().ReverseMap();
        CreateMap<CommentResultDto, Comment>().ReverseMap();

        CreateMap<ChatCreationDto, Chat>().ReverseMap();
        CreateMap<ChatResultDto, Chat>().ReverseMap();
        CreateMap<ChatUpdateDto, Chat>().ReverseMap();
    }
}
