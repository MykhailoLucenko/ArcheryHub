namespace ArcheryHub.Core.Entities.Users;

public class UserYearlyStats
{
    public string Nickname { get; set; }
    public int TotalRounds { get; set; }
    public int TotalArrows { get; set; }
    public double MidlArrow { get; set; }
    public int BestEndScore { get; set; }
    public string MostActiveMonth { get; set; }
}