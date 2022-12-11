using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Whatch.Dto;

namespace Whatch.Services;

public interface IFilmReviewService : ICrudAppService<FilmReviewDto, int, PagedAndSortedResultRequestDto, LeaveReviewDto>
{
}