using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Whatch.Dto;

namespace Whatch.Services;

public interface IActorService : ICrudAppService<ActorDto, int, PagedAndSortedResultRequestDto, CreateUpdateActorDto>
{
    
}