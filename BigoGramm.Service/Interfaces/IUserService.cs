using BigoGramm.Service.DTOs.User;

namespace BigoGramm.Service.Interfaces;

public interface IUserService
{
    Task<UserResultDto> CreateAsync(UserCreationDto dto);
    Task<UserResultDto> UpdateAsync(UserUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<UserUpdateDto>> GetAllUsersAsync();
    Task<UserResultDto> GetAsync(long Id);
}
