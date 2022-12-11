using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Whatch.Models;

public class Actor : AuditedAggregateRoot<int>
{
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Country { get; set; }
    public DateTime Birthday { get; set; }
    
    public virtual ICollection<FilmCast> Casts { get; set; }
}