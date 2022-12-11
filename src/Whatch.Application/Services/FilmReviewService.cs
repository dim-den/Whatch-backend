using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Whatch.Dto;
using Whatch.Models;
using Whatch.Permissions;

namespace Whatch.Services;

public class FilmReviewService : CrudAppService<FilmReview, FilmReviewDto, int, PagedAndSortedResultRequestDto, LeaveReviewDto>, IFilmReviewService
{
    public FilmReviewService(IRepository<FilmReview, int> repository) : base(repository)
    {
        CreatePolicyName = WhatchPermissions.LeaveReview;
        DeletePolicyName = WhatchPermissions.CrudOperations;
        UpdatePolicyName = WhatchPermissions.CrudOperations;
    }
}