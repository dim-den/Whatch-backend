using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Whatch.Enums;

namespace Whatch.Dto;

public class FilmSearchDto : EntityDto<int>
{
    public string Title { get; set; }
    public string Director { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Country { get; set; }
    public FilmGenre Genre { get; set; }
    public List<ActorDto> Actors { get; set; } = new();
}