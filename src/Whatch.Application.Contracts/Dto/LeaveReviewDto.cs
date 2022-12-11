using System;
using System.ComponentModel.DataAnnotations;

namespace Whatch.Dto;

public class LeaveReviewDto
{
    [Required]
    public int FilmId { get; set; }
    
    [Required]
    public Guid UserId { get; set; }
    
    [Required]
    [Range(1, 10)]
    public int Score { get; set; }
    
    [MaxLength(2048)]
    public string Review { get; set; }
}