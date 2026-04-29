namespace ArcheryHub.Core.Entities.Rounds;

public class RoundParticipant
{
    public required int UserId { get; set; }
    public required int RoundId { get; set; }
    public DateTime JoinedAt { get; set; }
}