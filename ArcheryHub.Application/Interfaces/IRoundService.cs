using ArcheryHub.Application.DTOs.Users;
using ArcheryHub.Core.Entities.Rounds;
namespace ArcheryHub.Application.Interfaces;

public interface IRoundService
{
    Task<int> CreateRoundAsync (CreateRoundDto request);
    Task<EndResponse?> SubmitEndAsync (EndRequest request);
    Task<IEnumerable<RoundLeaderBoard>> GetRoundLeaderBoardAsync(int roundId);
    Task<IEnumerable<GlobalRecords>> GetGlobalRecordsAsync();
}