using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Whatch.Dto;

namespace Whatch.Services;

public interface IFilmCastService : ICrudAppService<FilmCastDto, int, PagedAndSortedResultRequestDto, CreateUpdateFilmCastDto>
{
    public Task<List<FilmCastInfoDto>> GetFilmCast(GetFilmCastDto request);
    
    public Task<List<FilmDto>> GetActorFilms(GetActorFilmsDto request);

}