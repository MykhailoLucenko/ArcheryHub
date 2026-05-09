using ArcheryHub.Core.Entities.Users;
using ArcheryHub.Core.Interfaces.Users;
using ArcheryHub.Infrastructure.Database;
using Dapper;

namespace ArcheryHub.Infrastructure.Repositories;

public class FriendshipRepository : IFriendshipRepository
{
    private readonly DapperContext _context;

    public FriendshipRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task AddFriendAsync(int userId, int friendId)
    {
        var query = "CALL sp_AddFriend(@UserId, @FriendId);";

        using var connection = _context.CreateConnection();

        await connection.ExecuteAsync(query, new { UserId = userId, FriendId = friendId });
        
    }

    public async Task<IEnumerable<FriendActivity>> GetFriendActivity(int userId)
    {
        var query = "SELECT * FROM vw_FriendActivity WHERE owner_id = @UserId;";

        using var connection = _context.CreateConnection();

        var response = await connection.QueryAsync<FriendActivity>(query, new { UserId = userId });

        return response;

    }
}