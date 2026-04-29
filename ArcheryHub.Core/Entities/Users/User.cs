namespace ArcheryHub.Core.Entities.Users;

public class User
{
    public int UserId { get; set; }
    public required string Nickname { get; set; }
    public required string Email { get; set; }
    public DateTime RegisterAt { get; set; }
}