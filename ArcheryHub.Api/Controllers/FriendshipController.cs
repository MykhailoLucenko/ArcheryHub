using ArcheryHub.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArcheryHub.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class FriendshipController : ControllerBase
{

    private readonly IFriendshipService _friendshipService;

    public FriendshipController(IFriendshipService friendshipService)
    {
        _friendshipService = friendshipService;
    }

    [HttpPost("addFriends")]
    public async Task<IActionResult> AddFriend([FromBody] AddFriendRequest request)
    {
        await _friendshipService.AddFriendAsync(request.UserId, request.FriendId);

        return Ok();

    }

    [HttpGet("{userId}/friendActivity")]
    public async Task<IActionResult> GetFriendActivity([FromRoute] int userId)
    {
        var response = await _friendshipService.GetFriendActivity(userId);

        return Ok(response);

    }


    public class AddFriendRequest
    {
        public int UserId { get; set; }
        public int FriendId { get; set; }
    }
    

}