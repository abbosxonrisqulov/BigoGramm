namespace BigoGramm.Service.DTOs.Comment;

public class CommentResultDto
{
    public long Id { get; set; }
    public long PostId { get; set; }
    public long UserId { get; set; }
    public string Text { get; set; }
}
