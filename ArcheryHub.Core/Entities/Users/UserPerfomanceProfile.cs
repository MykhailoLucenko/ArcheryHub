namespace ArcheryHub.Core.Entities.Users;

public class UserPerformanceProfile
{
    public string Nickname { get; set; }
    public int TotalRounds { get; set; }
    public int TotalArrowsScore { get; set; }
    public double MidlArrows { get; set; }
    public int XInRounds { get; set; }
}