namespace BigoGramm.Service.DTOs.Comment;

public class CommentCreationDto
{
    public long PostId { get; set; }
    public long UserId { get; set; }
    public string Text { get; set; }
}
