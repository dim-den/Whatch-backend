using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Whatch.Enums;

namespace Whatch.Dto;

public class SearchFilmDto : PagedAndSortedResultRequestDto 
{
    [Required]
    public string Key { get; set; }
    [Required]
    public FilmFilterType FilterBy { get; set; }
}