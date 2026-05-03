using ArcheryHub.Core.Entities.Users;
using ArcheryHub.Core.Interfaces.Users;
using ArcheryHub.Infrastructure.Database;
using Dapper;

namespace ArcheryHub.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DapperContext _context;

    public UserRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<User?> LoginAsync(string identifier)
    {
        var query = "CALL sp_LoginUser(@Identifier);";

        using var connection = _context.CreateConnection();

        var user = await connection.QueryFirstOrDefaultAsync<User>(query, new { Identifier = identifier });

        return user;

    }

    public async Task<int> RegisterUserAsync(User user)
    {
        var query = "CALL sp_RegisterUser(@Nickname, @Email);";

        using var connection = _context.CreateConnection();

        var response = await connection.ExecuteScalarAsync<int>(query, param: user);

        return response;

    }

    public async Task<UserPerformanceProfile> GetUserPerformanceAsync(int userId)
    {
        var query = "SELECT * FROM vw_UserPerfomance WHERE user_id = @UserId;";

        using var connection = _context.CreateConnection();

        var response = await connection.QueryFirstOrDefaultAsync<UserPerformanceProfile>(query, new { UserId = userId });

        return response;

    }

    public async Task<UserYearlyStats?> GetUserYearlyStatsAsync(int userId, int year)
    {
        var query = "CALL sp_GetUserYearlyStats(@UserId, @Year);";

        using var connection = _context.CreateConnection();

        var response = await connection.QueryFirstOrDefaultAsync<UserYearlyStats>(query, new { UserId = userId, Year = year });

        return response;

    }
}