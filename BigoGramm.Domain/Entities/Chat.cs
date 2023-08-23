using BigoGramm.Domain.Commons;

namespace BigoGramm.Domain.Entities;

public class Chat : Auditable
{
    public long SendUserId { get; set; }
    public long RecieveUserId { get; set; }
    public string Message { get; set; }
}
