using System.Text.Json;
using ArcheryHub.Core.Entities.Rounds;
using ArcheryHub.Core.Interfaces.Rounds;
using ArcheryHub.Infrastructure.Database;
using Dapper;

namespace ArcheryHub.Infrastructure.Repositories;

public class RoundRepository : IRoundRepository
{
    private readonly DapperContext _context;

    public RoundRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<int> CreateRoundAsync(Round request)
    {
        var query = "CALL sp_CreateRound(@CreatedByUserId, @Title, @Distance, @TotalRoundEnds);";

        using var connection = _context.CreateConnection();

        var response = await connection.QuerySingleOrDefaultAsync<int>(query, param: request);

        return response;

    }

    public async Task<EndResponse?> SubmitEndAsync(EndRequest request)
    {
        var query = "CALL sp_SubmitEnd(@UserId, @RoundId, @ArrowsJson);";
        
        string jsonArrows = JsonSerializer.Serialize(request.Arrows);
        
        using var connection = _context.CreateConnection();

        var response = await connection.QueryFirstOrDefaultAsync<EndResponse>(query, new { UserId = request.UserId, RoundId = request.RoundId, ArrowsJson = jsonArrows });

        return response;

    }

    public async Task<IEnumerable<RoundLeaderBoard>> GetRoundLeaderBoardAsync(int roundId)
    {
        var query = "CALL sp_GetRoundLeaderBoard(@RoundId)";

        using var connection = _context.CreateConnection();

        var response = await connection.QueryAsync<RoundLeaderBoard>(query, new { RoundId = roundId });

        return response;

    }

    public async Task<IEnumerable<GlobalRecords>> GetGlobalRecordsAsync()
    {
        var query = "SELECT * FROM vw_GlobalRecords;";

        using var connection = _context.CreateConnection();

        var response = await connection.QueryAsync<GlobalRecords>(query);

        return response;

    }

    public async Task<bool> CheckRoundExistsAsync(int roundId)
    {
        var query = "SELECT EXISTS(SELECT 1 FROM rounds WHERE round_id = @RoundId);";

        using var connection = _context.CreateConnection();

        var response = await connection.ExecuteScalarAsync<int>(query, new{RoundId = roundId});

        return response > 0;

    }
}