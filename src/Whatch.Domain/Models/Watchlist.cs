using System;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;

namespace Whatch.Models;

public class Watchlist : BasicAggregateRoot<int>, IHasCreationTime
{
    public int FilmId { get; set; }
    public Film Film { get; set; }
    
    public DateTime CreationTime { get; set; } = DateTime.Now;

    public Guid UserId { get; set; }
    public IdentityUser User { get; set; }
}