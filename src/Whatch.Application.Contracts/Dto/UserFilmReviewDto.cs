using Volo.Abp.Application.Dtos;

namespace Whatch.Dto;

public class UserFilmReviewDto : AuditedEntityDto<int>
{
    public int Score { get; set; }
    public string Review { get; set; }
    public FilmDto Film { get; set; }
}