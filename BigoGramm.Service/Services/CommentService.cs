using AutoMapper;
using BigoGramm.DAL.IRepositories;
using BigoGramm.Domain.Entities;
using BigoGramm.Service.DTOs.Comment;
using BigoGramm.Service.DTOs.Post;
using BigoGramm.Service.Exceptions;
using BigoGramm.Service.Interfaces;

namespace BigoGramm.Service.Services;

public class CommentService : ICommentService
{

    private readonly IRepository<Comment> repository;
    private readonly IMapper mapper;

    public CommentService(IRepository<Comment> repository, IMapper mapper)
    {
        this.mapper = mapper;
        this.repository = repository;
    }
    public async Task<CommentResultDto> CreateAsync(CommentCreationDto dto)
    {
        var mapped = mapper.Map<Comment>(dto);
        await repository.CreateAsync(mapped);
        await repository.SaveChanges();

        var result = mapper.Map<CommentResultDto>(mapped);

        return (result);
    }
}
