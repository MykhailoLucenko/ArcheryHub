using ArcheryHub.Application.Exceptions;
using ArcheryHub.Application.Interfaces;
using ArcheryHub.Core.Entities.Users;
using ArcheryHub.Core.Interfaces.Users;
using MySqlConnector;

namespace ArcheryHub.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<int> RegisterUserAsync(User user)
    {
        try
        {
            return await _userRepository.RegisterUserAsync(user);
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

    public async Task<User?> LoginAsync(string identifier)
    {
        var user = await _userRepository.LoginAsync(identifier);

        if (user == null)
        {
            throw new NotFoundException("User with this nickname or email is not find");
        }

        return user;

    }

    public async Task<UserPerformanceProfile?> GetUserPerformanceAsync(int userId)
    {
        var response = await _userRepository.GetUserPerformanceAsync(userId);

        if (response == null)
        {
            throw new NotFoundException("User with this id is not find");
        }

        return response;

    }

    public async Task<UserYearlyStats?> GetUserYearlyStatsAsync(int userId, int year)
    {
        var response = await _userRepository.GetUserYearlyStatsAsync(userId, year);

        if (response == null)
        {
            throw new NotFoundException("User with this id is not find");
        }

        return response;

    }
}