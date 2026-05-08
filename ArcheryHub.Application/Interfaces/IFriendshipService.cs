using ArcheryHub.Core.Entities.Users;

namespace ArcheryHub.Application.Interfaces;

public interface IFriendshipService
{
    Task AddFriendAsync(int userId, int friendId);
    Task<IEnumerable<FriendActivity>> GetFriendActivity(int userId);
}