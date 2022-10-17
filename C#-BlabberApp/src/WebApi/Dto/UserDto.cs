namespace WebApi.Dto;

public class UserDto
{
    public UserDto(string? username, string? email, string? firstName, string? lastName)
    {
        Username = username;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }

    public string? Username { get; }
    public string? Email { get; }
    public string? FirstName { get; }
    public string? LastName { get; }
}