using ArcheryHub.Core.Entities.Users;

namespace ArcheryHub.Core.Interfaces.Users;

public interface IFriendshipRepository
{
    Task AddFriendAsync(int userId, int friendId);
    Task<IEnumerable<FriendActivity>> GetFriendActivity(int userId);
}