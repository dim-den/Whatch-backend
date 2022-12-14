using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace Whatch.Models;

public class FilmCast : BasicAggregateRoot<int>
{
    public string RoleName { get; set; }
    
    public int FilmId { get; set; }
    public Film Film { get; set; }
    
    public int ActorId { get; set; }
    public Actor Actor { get; set; }
}