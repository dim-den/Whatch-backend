using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Whatch.Dto;

public class FilmReviewsInfoDto : EntityDto
{
    public double AvgScore { get; set; }
    
    public double? CurrentUserFilmScore { get; set; }
    public string CurrentUserFilmReview { get; set; }
    
    public List<FilmReviewInfoDto> Reviews { get; set; }
    
}