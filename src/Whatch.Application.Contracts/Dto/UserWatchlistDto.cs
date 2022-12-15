using Volo.Abp.Application.Dtos;

namespace Whatch.Dto;

public class UserWatchlistDto : AuditedEntityDto<int>
{
    public FilmDto Film { get; set; }
}