using System;
using Volo.Abp.Application.Dtos;
using Whatch.Enums;

namespace Whatch.Dto;

public class FilmDto : EntityDto<int>
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

}