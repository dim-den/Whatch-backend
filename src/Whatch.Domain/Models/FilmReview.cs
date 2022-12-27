using System;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;

namespace Whatch.Models;

public class FilmReview : BasicAggregateRoot<int>, IHasCreationTime
{
    public string Review { get; set; }
    public int Score { get; set; }
    
    public DateTime CreationTime { get; set; } = DateTime.Now;

    
    public int FilmId { get; set; }
    public Film Film { get; set; }
    
    public Guid UserId { get; set; }
    public IdentityUser User { get; set; }
}