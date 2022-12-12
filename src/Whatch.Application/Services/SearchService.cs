using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Whatch.Dto;
using Whatch.Models;
using Whatch.Repositories;

namespace Whatch.Services;

public class SearchService : WhatchAppService, ISearchService
{
    private readonly ISearchRepository _repository;

    public SearchService(ISearchRepository repository)
    {
        _repository = repository;
    }

    public async Task<PagedResultDto<FilmDto>> GetSearchFilm(SearchFilmDto request)
    {
        var films = await _repository.SearchFilm(request.Key, request.FilterBy, request.MaxResultCount);
        var totalCount = films.Count;
        films = films.Skip(request.SkipCount).Take(request.MaxResultCount).ToList();

        var filmsDto = ObjectMapper.Map<List<Film>, List<FilmDto>>(films);

        return new PagedResultDto<FilmDto>(
            totalCount,
            filmsDto
        );
    }
}