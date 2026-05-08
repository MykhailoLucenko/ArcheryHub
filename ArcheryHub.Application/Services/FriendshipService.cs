using ArcheryHub.Application.Exceptions;
using ArcheryHub.Application.Interfaces;
using ArcheryHub.Core.Entities.Users;
using ArcheryHub.Core.Interfaces.Users;
using MySqlConnector;

namespace ArcheryHub.Application.Services;

public class FriendshipService : IFriendshipService
{
    private readonly IFriendshipRepository _friendshipRepository;
    private readonly IUserRepository _userRepository;

    public FriendshipService(IFriendshipRepository friendshipRepository, IUserRepository userRepository)
    {
        _friendshipRepository = friendshipRepository;
        _userRepository = userRepository;
    }

    public async Task AddFriendAsync(int userId, int friendId)
    {
        try
        {
            await _friendshipRepository.AddFriendAsync(userId, friendId);
        }
        catch (MySqlException ex)
        {
            if (ex.Number == 1644)
            {
                throw new DomainValidationException(ex.Message);
            }

            throw; 
        }
    }

    public async Task<IEnumerable<FriendActivity>> GetFriendActivity(int userId)
    {
        
        var userExists = await _userRepository.CheckUserExistsAsync(userId);
        
        if (!userExists)
        {
            throw new NotFoundException($"User with this id: {userId} is not found.");
        }
        
        var response = await _friendshipRepository.GetFriendActivity(userId);

        return response;

    }
}