using System;
using System.ComponentModel.DataAnnotations;
using Whatch.Enums;

namespace Whatch.Dto;

public class CreateUpdateFilmDto
{
    [MaxLength(255)]
    [Required]
    public string Title { get; set; }
    [MaxLength(2048)]
    public string Description { get; set; }
    [MaxLength(255)]
    public string Director { get; set; }
    public int Budget { get; set; }
    public int Fees { get; set; }
    [Required]
    public DateTime RealeaseDate { get; set; }
    [MaxLength(255)]
    [Required]
    public string Country { get; set; }
    [Range((int)FilmGenre.Action, (int)FilmGenre.Western)]
    public FilmGenre Genre { get; set; }
    [MaxLength(255)]
    public string TrailerUrl { get; set; }
}