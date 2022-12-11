namespace Whatch.Dto;

public class CreateUpdateFilmCastDto
{
    public string RoleName { get; set; }
    
    public int FilmId { get; set; }
    public int ActorId { get; set; }
}