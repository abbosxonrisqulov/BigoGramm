using BigoGramm.Domain.Commons;

namespace BigoGramm.Domain.Entities;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Nickname { get; set; }
    public ICollection<Post> Posts { get; set; }
    public ICollection<Chat> Chats { get; set; }
}
