using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace Whatch.Models;

public class Watchlist : AuditedAggregateRoot<int>
{
    public int FilmId { get; set; }
    public Film Film { get; set; }
    
    public Guid UserId { get; set; }
    public IdentityUser User { get; set; }
}