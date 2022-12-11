using System.ComponentModel.DataAnnotations;

namespace Whatch.Dto;

public class CreateUpdateFilmCastDto
{
    [Required]
    [MaxLength(255)]
    public string RoleName { get; set; }
    [Required]
    public int FilmId { get; set; }
    [Required]
    public int ActorId { get; set; }
}