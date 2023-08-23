using AutoMapper;
using BigoGramm.DAL.IRepositories;
using BigoGramm.Domain.Entities;
using BigoGramm.Service.DTOs.Chat;
using BigoGramm.Service.DTOs.User;
using BigoGramm.Service.Exceptions;
using BigoGramm.Service.Interfaces;

namespace BigoGramm.Service.Services;

public class ChatService : IChatService
{

    private readonly IRepository<Chat> repository;
    private readonly IMapper mapper;

    public ChatService(IRepository<Chat> repository, IMapper mapper)
    {
        this.mapper = mapper;
        this.repository = repository;
    }
    public async Task<ChatResultDto> CreateAsync(ChatCreationDto dto)
    {

        var mapped = mapper.Map<Chat>(dto);
        await repository.CreateAsync(mapped);
        await repository.SaveChanges();

        var result = mapper.Map<ChatResultDto>(mapped);

        return (result);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        Chat existChat = await repository.GetAsync(x => x.Id.Equals(id));

        if (existChat is null)
        {
            throw new NotFoundException("This Chat not found");
        }

        repository.Delete(existChat);
        await repository.SaveChanges();

        return true;
    }

    public async Task<ChatResultDto> UpdateAsync(ChatUpdateDto dto)
    {
        Chat existChat = await repository.GetAsync(x => x.Id.Equals(dto.Id));

        if (existChat is null)
        {
            throw new NotFoundException("This Chat not found");
        }

        mapper.Map(dto, existChat);
        this.repository.Update(existChat);
        await repository.SaveChanges();

        var result = mapper.Map<ChatResultDto>(existChat);
        return result;
    }
}
