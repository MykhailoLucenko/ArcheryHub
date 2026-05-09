using ArcheryHub.Application.DTOs.Users;
using ArcheryHub.Core.Entities.Users;

namespace ArcheryHub.Application.Interfaces;

public interface IUserService
{
    Task<int> RegisterUserAsync (CreateUserDto user);
    Task<User?> LoginAsync (string identifier);
    Task<UserPerformanceProfile?> GetUserPerformanceAsync (int userId);
    Task<UserYearlyStats?> GetUserYearlyStatsAsync (int userId, int year);
}