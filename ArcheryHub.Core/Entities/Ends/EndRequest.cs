namespace ArcheryHub.Core.Entities.Rounds;

public class EndRequest
{
    public int UserId { get; set; }
    public int RoundId { get; set; }
    public int EndNumber { get; set; }
    public List<int> Arrows { get; set; }
    
}