using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Whatch.Dto;
using Whatch.Models;
using Whatch.Permissions;

namespace Whatch.Services;

public class FilmCastService : CrudAppService<FilmCast, FilmCastDto, int, PagedAndSortedResultRequestDto, CreateUpdateFilmCastDto>, IFilmCastService
{
    public FilmCastService(IRepository<FilmCast, int> repository) : base(repository)
    {
        CreatePolicyName = WhatchPermissions.CrudOperations;
        DeletePolicyName = WhatchPermissions.CrudOperations;
        UpdatePolicyName = WhatchPermissions.CrudOperations;
    }
}