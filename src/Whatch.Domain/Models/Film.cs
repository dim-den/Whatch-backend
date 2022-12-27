using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Whatch.Enums;

namespace Whatch.Models;

public class Film : BasicAggregateRoot<int>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Director { get; set; }
    public int Budget { get; set; }
    public int Fees { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Country { get; set; }
    public FilmGenre Genre { get; set; }
    public string TrailerUrl { get; set; }
    
    public virtual ICollection<FilmCast> Casts { get; set; }
    public virtual ICollection<FilmReview> Reviews { get; set; }
}