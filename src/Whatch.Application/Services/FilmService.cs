using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Whatch.Dto;
using Whatch.Models;

namespace Whatch.Services;

public class FilmService: CrudAppService<Film, FilmDto, int, PagedAndSortedResultRequestDto, CreateUpdateFilmDto>, IFilmService
{
    public FilmService(IRepository<Film, int> repository) : base(repository)
    {
    }
}