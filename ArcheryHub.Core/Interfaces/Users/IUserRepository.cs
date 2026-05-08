using ArcheryHub.Core.Entities.Users;

namespace ArcheryHub.Core.Interfaces.Users;

public interface IUserRepository
{
    Task<int> RegisterUserAsync (User user);
    Task<User?> LoginAsync (string identifier);
    Task<UserPerformanceProfile?> GetUserPerformanceAsync(int userId);
    Task<UserYearlyStats?> GetUserYearlyStatsAsync (int userId, int year);
    
    Task<bool> CheckUserExistsAsync(int userId);
    
}