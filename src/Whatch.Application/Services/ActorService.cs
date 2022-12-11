using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Whatch.Dto;
using Whatch.Models;

namespace Whatch.Services;

public class ActorService : CrudAppService<Actor, ActorDto, int, PagedAndSortedResultRequestDto, CreateUpdateActorDto>, IActorService
{
    public ActorService(IRepository<Actor, int> repository) : base(repository)
    {
    }
}