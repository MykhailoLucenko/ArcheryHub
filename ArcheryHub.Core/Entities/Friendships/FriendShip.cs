namespace ArcheryHub.Core.Entities.Users;

public class FriendShip
{
    public required int UserId { get; set; }
    public required int FriendId { get; set; }
    public DateTime CreatedAt { get; set; }
}