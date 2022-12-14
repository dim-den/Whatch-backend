using System.ComponentModel.DataAnnotations;

namespace Whatch.Dto;

public class GetFilmCastDto
{
    [Required]
    public int FilmId { get; set; }
}