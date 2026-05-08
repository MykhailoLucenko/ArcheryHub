using ArcheryHub.Core.Entities.Users;

namespace ArcheryHub.Application.Interfaces;

public interface IUserService
{
    Task<int> RegisterUserAsync (User user);
    Task<User?> LoginAsync (string identifier);
    Task<UserPerformanceProfile?> GetUserPerformanceAsync (int userId);
    Task<UserYearlyStats?> GetUserYearlyStatsAsync (int userId, int year);
}