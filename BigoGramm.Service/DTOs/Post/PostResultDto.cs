using BigoGramm.Service.DTOs.Comment;

namespace BigoGramm.Service.DTOs.Post;

public class PostResultDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public ICollection<CommentResultDto> Comments { get; set; }
}