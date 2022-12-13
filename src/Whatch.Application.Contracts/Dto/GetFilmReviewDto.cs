using System;
using System.ComponentModel.DataAnnotations;

namespace Whatch.Dto;

public class GetFilmReviewDto
{
    [Required]
    [Range(1, Int32.MaxValue)]
    public int filmId { get; set; }
}