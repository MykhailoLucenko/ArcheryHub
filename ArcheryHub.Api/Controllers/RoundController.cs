using ArcheryHub.Application.DTOs.Users;
using ArcheryHub.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ArcheryHub.Core.Entities.Rounds;

namespace ArcheryHub.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class RoundController : ControllerBase
{

    private readonly IRoundService _roundService;

    public RoundController(IRoundService roundService)
    {
        _roundService = roundService;
    }

    [HttpPost("createRound")]
    public async Task<IActionResult> CreateRound([FromBody] CreateRoundDto request)
    {
        var response = await _roundService.CreateRoundAsync(request);

        return Ok(new { roundId = response });

    }

    [HttpPost("submitEnd")]
    public async Task<IActionResult> SubmitEnd([FromBody] EndRequest request)
    {
        var response = await _roundService.SubmitEndAsync(request);

        return Ok(response);

    }

    [HttpGet("records")]
    public async Task<IActionResult> GetGlobalRecords()
    {
        var response = await _roundService.GetGlobalRecordsAsync();

        return Ok(response);

    }

    [HttpGet("{roundId}/roundLeaderBoard")]
    public async Task<IActionResult> GetRoundLeaderBoard([FromRoute] int roundId)
    {
        var response = await _roundService.GetRoundLeaderBoardAsync(roundId);

        return Ok(response);

    }

}