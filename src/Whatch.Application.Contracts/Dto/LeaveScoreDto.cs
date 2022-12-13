using System.ComponentModel.DataAnnotations;

namespace Whatch.Dto;

public class LeaveScoreDto
{
    [Required] public int FilmId { get; set; }

    [Required]
    [Range(1, 10)]
    public int Score { get; set; }
}