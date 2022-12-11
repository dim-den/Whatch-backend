using System;
using Volo.Abp.Application.Dtos;

namespace Whatch.Dto;

public class FilmReviewDto : AuditedEntityDto<int>
{
    public string Review { get; set; }
    public int Score { get; set; }
    public int FilmId { get; set; }
    public Guid UserId { get; set; }
}