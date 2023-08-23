using BigoGramm.Service.DTOs.Comment;
using BigoGramm.Service.DTOs.Post;

namespace BigoGramm.Service.Interfaces;

public interface ICommentService
{
    Task<CommentResultDto> CreateAsync(CommentCreationDto dto);
}
