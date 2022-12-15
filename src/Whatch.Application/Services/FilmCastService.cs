using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
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

    public async Task<List<FilmCastInfoDto>> GetFilmCast(GetFilmCastDto request)
    {
        var casts = await Repository.GetQueryableAsync();
        
        var result = casts.Where(x => x.FilmId == request.FilmId)
            .ProjectTo<FilmCastInfoDto>(ObjectMapper.GetMapper().ConfigurationProvider)
            .ToList();
        

        return result;
    }

    public async Task<List<FilmDto>> GetActorFilms(GetActorFilmsDto request)
    {
        var casts = await Repository.GetQueryableAsync();
        
        var result = casts.Where(x => x.ActorId == request.ActorId)
            .Select(x => x.Film)
            .ProjectTo<FilmDto>(ObjectMapper.GetMapper().ConfigurationProvider)
            .ToList();

        return result;    
    }
}