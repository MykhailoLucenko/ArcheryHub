using ArcheryHub.Application.DTOs.Users;
using ArcheryHub.Application.Exceptions;
using ArcheryHub.Application.Interfaces;
using ArcheryHub.Core.Entities.Rounds;
using ArcheryHub.Core.Interfaces.Rounds;
using ArcheryHub.Core.Interfaces.Users;
using MySqlConnector;

namespace ArcheryHub.Application.Services;

public class RoundService : IRoundService
{
    private readonly IRoundRepository _roundRepository;
    private readonly IUserRepository _userRepository;

    public RoundService(IRoundRepository roundRepository, IUserRepository userRepository)
    {
        _roundRepository = roundRepository;
        _userRepository = userRepository;
    }


    public async Task<int> CreateRoundAsync(CreateRoundDto request)
    {
        Round newRound = new Round
        {
            CreatedByUserId = request.CreatedByUserId,
            Title = request.Title,
            Distance = request.Distance,
            TotalRoundEnds = request.TotalRoundEnds,
            ArrowsPerEnd = request.ArrowsPerEnd
        };
        return await _roundRepository.CreateRoundAsync(newRound);
    }


    public async Task<IEnumerable<GlobalRecords>> GetGlobalRecordsAsync()
    {
        return await _roundRepository.GetGlobalRecordsAsync();
    }

    public async Task<IEnumerable<RoundLeaderBoard>> GetRoundLeaderBoardAsync(int roundId)
    {
        var roundExists = await _roundRepository.CheckRoundExistsAsync(roundId);

        if (!roundExists)
        {
            throw new NotFoundException($"Round with this id: {roundId} is not found.");
        }

        return await _roundRepository.GetRoundLeaderBoardAsync(roundId);

    }

    public async Task<EndResponse?> SubmitEndAsync(EndRequest request)
    {
        try
        {
            var userExists = await _userRepository.CheckUserExistsAsync(request.UserId);

            if (!userExists)
            {
                throw new NotFoundException($"User with this id: {request.UserId} is not found.");
            }

            var roundExists = await _roundRepository.CheckRoundExistsAsync(request.RoundId);


            if (!roundExists)
            {
                throw new NotFoundException($"Round with this id: {request.RoundId} is not found.");
            }

            return await _roundRepository.SubmitEndAsync(request);

        }
        catch (MySqlException ex)
        {
            if (ex.Number == 1644)
            {
                throw new DomainValidationException(ex.Message);
            }

            throw;

        }
    }
}