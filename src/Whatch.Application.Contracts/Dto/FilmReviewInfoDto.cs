using Volo.Abp.Application.Dtos;

namespace Whatch.Dto;

public class FilmReviewInfoDto : AuditedEntityDto<int>
{
    public string Username { get; set; }
    public int Score { get; set; }
    public string Review { get; set; }
}