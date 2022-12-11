using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Whatch.Dto;
using Whatch.Models;

namespace Whatch.Services;

public class FilmCastService : CrudAppService<FilmCast, FilmCastDto, int, PagedAndSortedResultRequestDto, CreateUpdateFilmCastDto>, IFilmCastService
{
    public FilmCastService(IRepository<FilmCast, int> repository) : base(repository)
    {
    }
}