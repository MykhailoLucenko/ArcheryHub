namespace ArcheryHub.Core.Entities.Arrows;

public class Arrow
{
    public int ArrowId { get; set; }
    public required int EndId { get; set; }
    public required int Score { get; set; }
    public bool IsX { get; set; }
}