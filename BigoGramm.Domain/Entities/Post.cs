using BigoGramm.Domain.Commons;

namespace BigoGramm.Domain.Entities;

public class Post : Auditable
{
    public long UserId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public ICollection<Comment> Comments { get; set;}
}
