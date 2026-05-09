namespace ArcheryHub.Application.DTOs.Users;

public class CreateUserDto
{
    public required string Nickname { get; set; }
    public required string Email { get; set; }
}