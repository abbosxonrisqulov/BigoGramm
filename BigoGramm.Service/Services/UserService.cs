using AutoMapper;
using BigoGramm.DAL.IRepositories;
using BigoGramm.Domain.Entities;
using BigoGramm.Service.DTOs.User;
using BigoGramm.Service.Exceptions;
using BigoGramm.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BigoGramm.Service.Services;

public class UserService : IUserService
{
    private readonly IRepository<User> repository;
    private readonly IMapper mapper;

    public UserService(IRepository<User> repository, IMapper mapper)
    {
        this.mapper = mapper;
        this.repository = repository;
    }
    public async Task<UserResultDto> CreateAsync(UserCreationDto dto)
    {
        User existUser = await repository.GetAsync(x => x.Nickname.Equals(dto.Nickname));
        if (existUser is not null)
            throw new AlreadyExistException("This nickname already exist");

        var mapped = mapper.Map<User>(dto);
        await repository.CreateAsync(mapped);
        await repository.SaveChanges();

        var result = mapper.Map<UserResultDto>(mapped);

        return (result);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        User existUser = await repository.GetAsync(x => x.Id.Equals(id));

        if (existUser is null)
        {
            throw new NotFoundException("This user not found");
        }

        repository.Delete(existUser);
        await repository.SaveChanges();

        return true;
    }

    public async Task<IEnumerable<UserUpdateDto>> GetAllUsersAsync()
    {
        var users = await repository.GetAll().ToListAsync();
        var result = mapper.Map<IEnumerable<UserUpdateDto>>(users);
        return result;
    }

    public async Task<UserResultDto> GetAsync(long Id)
    {
        var existUser = await repository.GetAsync(x => x.Id.Equals(Id),includes: new[] {"Posts.Comments","Chats"});
        if (existUser is null)
            throw new NotFoundException("This user not found");

        var result = mapper.Map<UserResultDto>(existUser);
        return result;
    }

    public async Task<UserResultDto> UpdateAsync(UserUpdateDto dto)
    {
        User existUser = await repository.GetAsync(x => x.Id.Equals(dto.Id));

        if (existUser is null)
        {
            throw new NotFoundException("This user not found");
        }

        mapper.Map(dto, existUser);
        this.repository.Update(existUser);
        await repository.SaveChanges();

        var result = mapper.Map<UserResultDto>(existUser);
        return result;
    }
}
