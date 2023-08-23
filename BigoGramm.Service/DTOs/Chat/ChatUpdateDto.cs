namespace BigoGramm.Service.DTOs.Chat;

public class ChatUpdateDto
{
    public long Id { get; set; }
    public long SendUserId { get; set; }
    public long RecieveUserId { get; set; }
    public string Message { get; set; }
}

