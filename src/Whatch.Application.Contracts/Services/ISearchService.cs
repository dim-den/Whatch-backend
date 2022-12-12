using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Whatch.Dto;

namespace Whatch.Services;

public interface ISearchService : IApplicationService
{
    Task<PagedResultDto<FilmDto>> GetSearchFilm(SearchFilmDto request);
}