using Volo.Abp.Application.Dtos;

namespace Whatch.Dto;

public class FilmCastDto : AuditedEntityDto<int>
{
    public string RoleName { get; set; }
    public int FilmId { get; set; }
    public int ActorId { get; set; }
}