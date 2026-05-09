namespace ArcheryHub.Application.DTOs.Users;

public class CreateRoundDto
{
    public required int CreatedByUserId { get; set; }
    public required string Title { get; set; }
    public required int Distance { get; set; }
    public required int TotalRoundEnds { get; set; }
    public required int ArrowsPerEnd { get; set; }
}