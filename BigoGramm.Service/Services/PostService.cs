using AutoMapper;
using BigoGramm.DAL.IRepositories;
using BigoGramm.Domain.Entities;
using BigoGramm.Service.DTOs.Post;
using BigoGramm.Service.DTOs.User;
using BigoGramm.Service.Exceptions;
using BigoGramm.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BigoGramm.Service.Services;

public class PostService : IPostService
{
    private readonly IRepository<Post> repository;
    private readonly IMapper mapper;

    public PostService(IRepository<Post> repository, IMapper mapper)
    {
        this.mapper = mapper;
        this.repository = repository;
    }
    public async Task<PostResultDto> CreateAsync(PostCreationDto dto)
    {

        var mapped = mapper.Map<Post>(dto);
        await repository.CreateAsync(mapped);
        await repository.SaveChanges();

        var result = mapper.Map<PostResultDto>(mapped);

        return (result);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        Post existPost = await repository.GetAsync(x => x.Id.Equals(id));

        if (existPost is null)
        {
            throw new NotFoundException("This Post not found");
        }

        repository.Delete(existPost);
        await repository.SaveChanges();

        return true;
    }

    public async Task<IEnumerable<PostUpdateDto>> GetAllPostsAsync()
    {
        var Posts = await repository.GetAll().ToListAsync();
        var result = mapper.Map<IEnumerable<PostUpdateDto>>(Posts);
        return result;
    }

    public async Task<PostResultDto> GetAsync(long Id)
    {
        var existPost = await repository.GetAsync(x => x.Id.Equals(Id),includes: new[] {"Comments"});
        if (existPost is null)
            throw new NotFoundException("This Post not found");

        var result = mapper.Map<PostResultDto>(existPost);
        return result;
    }

    public async Task<PostResultDto> UpdateAsync(PostUpdateDto dto)
    {
        Post existPost = await repository.GetAsync(x => x.Id.Equals(dto.Id));

        if (existPost is null)
        {
            throw new NotFoundException("This Post not found");
        }

        mapper.Map(dto, existPost);
        this.repository.Update(existPost);
        await repository.SaveChanges();

        var result = mapper.Map<PostResultDto>(existPost);
        return result;
    }
}
