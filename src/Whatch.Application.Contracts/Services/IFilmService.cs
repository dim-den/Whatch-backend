using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Whatch.Dto;

namespace Whatch.Services;

public interface IFilmService : ICrudAppService<FilmDto, int, PagedAndSortedResultRequestDto, CreateUpdateFilmDto>
{
    public Task<List<FilmWithScoreDto>> GetUserRecommendationFilms();
}