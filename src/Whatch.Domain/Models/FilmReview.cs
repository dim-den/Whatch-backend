using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace Whatch.Models;

public class FilmReview : AuditedAggregateRoot<int>
{
    public string Review { get; set; }
    public int Score { get; set; }
    
    public int FilmId { get; set; }
    public Film Film { get; set; }
    
    public Guid UserId { get; set; }
    public IdentityUser User { get; set; }
}