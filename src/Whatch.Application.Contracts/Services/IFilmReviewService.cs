using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Whatch.Dto;

namespace Whatch.Services;

public interface IFilmReviewService : ICrudAppService<FilmReviewDto, int, PagedAndSortedResultRequestDto, CreateUpdateFilmReviewDto>
{
    Task<FilmReviewDto> PostLeaveScore(LeaveScoreDto request);
    Task<FilmReviewDto> PostLeaveReview(LeaveReviewDto request);
    
    Task<FilmReviewsInfoDto> GetFilmReviewsInfo(GetFilmReviewDto request);

}