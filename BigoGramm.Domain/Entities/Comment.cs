using BigoGramm.Domain.Commons;

namespace BigoGramm.Domain.Entities;

public class Comment : Auditable
{
    public long PostId { get; set; }
    public long UserId { get; set; }
    public string Text { get; set; }
}
