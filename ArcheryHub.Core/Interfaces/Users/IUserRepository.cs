using ArcheryHub.Core.Entities.Users;

namespace ArcheryHub.Core.Interfaces.Users;

public interface IUserRepository
{
    Task<int> RegisterUserAsync (User user);
    Task<User?> LoginAsync (string request);
    Task<UserPerformanceProfile> GetUserPerformanceAsync (int userId);
    Task<UserYearlyStats?> GetUserYearlyStatsAsync (int userId, int year);
}