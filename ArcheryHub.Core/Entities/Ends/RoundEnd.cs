namespace ArcheryHub.Core.Entities.Rounds;

public class RoundEnd
{
    public int EndId { get; set; }
    public required int RoundId { get; set; }
    public required int UserId { get; set; }
    public required int EndNumber { get; set; }
    public DateTime ShotAt { get; set; }

}