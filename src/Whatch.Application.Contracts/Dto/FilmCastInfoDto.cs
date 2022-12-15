using Volo.Abp.Application.Dtos;

namespace Whatch.Dto;

public class FilmCastInfoDto : AuditedEntityDto<int>
{
    public string RoleName { get; set; }

    public ActorDto Actor { get; set; }
}