namespace ArcheryHub.Core.Entities.Users;

public class FriendActivity
{
    public string Nickname { get; set; }
    public int UserId { get; set; }
    public DateTime LastActive { get; set; }
}