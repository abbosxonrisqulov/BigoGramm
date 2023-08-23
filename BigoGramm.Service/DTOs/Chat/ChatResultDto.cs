namespace BigoGramm.Service.DTOs.Chat;

public class ChatResultDto
{
    public long Id { get; set; }
    public long SendUserId { get; set; }
    public long RecieveUserId { get; set; }
    public string Message { get; set; }
}

