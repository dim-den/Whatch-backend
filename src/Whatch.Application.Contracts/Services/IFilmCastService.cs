using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Whatch.Dto;

namespace Whatch.Services;

public interface IFilmCastService : ICrudAppService<FilmCastDto, int, PagedAndSortedResultRequestDto, CreateUpdateFilmCastDto>
{
    
}