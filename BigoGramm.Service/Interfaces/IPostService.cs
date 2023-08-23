using BigoGramm.Service.DTOs.Post;

namespace BigoGramm.Service.Interfaces;

public interface IPostService
{
    Task<PostResultDto> CreateAsync(PostCreationDto dto);
    Task<PostResultDto> UpdateAsync(PostUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<PostUpdateDto>> GetAllPostsAsync();
    Task<PostResultDto> GetAsync(long Id);
}
