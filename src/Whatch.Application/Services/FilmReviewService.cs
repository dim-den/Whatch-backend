using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Whatch.Dto;
using Whatch.Models;

namespace Whatch.Services;

public class FilmReviewService : CrudAppService<FilmReview, FilmReviewDto, int, PagedAndSortedResultRequestDto, LeaveReviewDto>, IFilmReviewService
{
    public FilmReviewService(IRepository<FilmReview, int> repository) : base(repository)
    {
    }
}