using BigoGramm.Service.DTOs.Chat;
using BigoGramm.Service.DTOs.User;

namespace BigoGramm.Service.Interfaces;

public interface IChatService
{
    Task<ChatResultDto> CreateAsync(ChatCreationDto dto);
    Task<ChatResultDto> UpdateAsync(ChatUpdateDto dto);
    Task<bool> DeleteAsync(long id);
}
