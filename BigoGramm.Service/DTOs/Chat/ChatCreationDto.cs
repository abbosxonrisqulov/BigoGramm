namespace BigoGramm.Service.DTOs.Chat;

public class ChatCreationDto
{
    public long SendUserId { get; set; }
    public long RecieveUserId { get; set; }
    public string Message { get; set; }
}

