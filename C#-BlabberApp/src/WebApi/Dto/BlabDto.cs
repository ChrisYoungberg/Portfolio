namespace WebApi.Dto;

public class BlabDto
{
    public BlabDto(string? username, string? content)
    {
        Username = username;
        Content = content;
    }

    public string? Username { get; }
    public string? Content { get; }
}