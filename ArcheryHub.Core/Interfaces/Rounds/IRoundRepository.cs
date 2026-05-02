using ArcheryHub.Core.Entities.Rounds;

namespace ArcheryHub.Core.Interfaces.Rounds;

public interface IRoundRepository
{
    Task<Round> CreateRoundAsync (Round request);
    Task<EndResponse> SubmitEndAsync (EndRequest request);
    Task<IEnumerable<RoundLeaderBoard>> GetRoundLeaderBoardAsync(int roundId);
    Task<IEnumerable<GlobalRecords>> GetGlobalRecordsAsync();

}