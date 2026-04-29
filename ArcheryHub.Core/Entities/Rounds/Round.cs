namespace ArcheryHub.Core.Entities.Rounds;

public class Round
{
    public int RoundId { get; set; }
    public required int CreatedByUserId { get; set; }
    public required string Title { get; set; }
    public required int Distance { get; set; }
    public required int TotalRoundEnds { get; set; }
    public DateTime CreatedAt { get; set; }

}