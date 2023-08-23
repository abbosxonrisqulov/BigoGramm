namespace BigoGramm.Service.DTOs.User;

public class UserCreationDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Nickname { get; set; }
}
