using ArcheryHub.Core.Entities.Rounds;

namespace ArcheryHub.Core.Interfaces.Rounds;

public interface IRoundRepository
{
    Task<int> CreateRoundAsync (Round request);
    Task<EndResponse?> SubmitEndAsync (EndRequest request);
    Task<IEnumerable<RoundLeaderBoard>> GetRoundLeaderBoardAsync(int roundId);
    Task<IEnumerable<GlobalRecords>> GetGlobalRecordsAsync();

    Task<bool> CheckRoundExistsAsync(int roundId);


}