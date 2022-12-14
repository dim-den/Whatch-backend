using System.ComponentModel.DataAnnotations;

namespace Whatch.Dto;

public class GetActorFilmsDto
{
    [Required]
    public int ActorId { get; set; }
}