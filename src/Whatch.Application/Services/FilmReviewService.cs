using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Users;
using Whatch.Dto;
using Whatch.Models;
using Whatch.Permissions;

namespace Whatch.Services;

public class FilmReviewService : CrudAppService<FilmReview, FilmReviewDto, int, PagedAndSortedResultRequestDto, CreateUpdateFilmReviewDto>, IFilmReviewService
{
    private readonly ICurrentUser _currentUser;

    public FilmReviewService(IRepository<FilmReview, int> repository, ICurrentUser currentUser) : base(repository)
    {
        _currentUser = currentUser;
        CreatePolicyName = WhatchPermissions.CrudOperations;
        DeletePolicyName = WhatchPermissions.LeaveReview;
        UpdatePolicyName = WhatchPermissions.CrudOperations;
    }

    [Authorize(WhatchPermissions.LeaveReview)]
    public async Task<FilmReviewDto> PostLeaveScore(LeaveScoreDto request)
    {
        var userId =_currentUser.Id;

        var reviews = await Repository.GetQueryableAsync();

        var review = reviews.FirstOrDefault(x => x.UserId == userId && x.FilmId == request.FilmId);

        if (review is null)
        {
            review = new FilmReview
            {
                UserId = (Guid)userId!,
                FilmId = request.FilmId,
                Score = request.Score
            };
                
            review = await Repository.InsertAsync(review);
        }
        else
        {
            review.Score = request.Score;

            review = await Repository.UpdateAsync(review);
        }

        return ObjectMapper.Map<FilmReview, FilmReviewDto>(review);
    }

    [Authorize(WhatchPermissions.LeaveReview)]
    public async Task<FilmReviewDto> PostLeaveReview(LeaveReviewDto request)
    {
        var userId =_currentUser.Id;

        var reviews = await Repository.GetQueryableAsync();

        var review = reviews.FirstOrDefault(x => x.UserId == userId && x.FilmId == request.FilmId);

        if (review is null)
        {
            review = new FilmReview
            {
                UserId = (Guid)userId!,
                FilmId = request.FilmId,
                Score = request.Score,
                Review = request.Review
            };
                
            review = await Repository.InsertAsync(review);
        }
        else
        {
            review.Score = request.Score;
            review.Review = request.Review;

            review = await Repository.UpdateAsync(review);
        }

        return ObjectMapper.Map<FilmReview, FilmReviewDto>(review);    
    }

    public async Task<FilmReviewsInfoDto> GetFilmReviewsInfo(GetFilmReviewDto request)
    {
        var reviews = await Repository.GetQueryableAsync();

        var items = reviews.Where(x => x.FilmId == request.filmId)
            .ProjectTo<FilmReviewInfoDto>(ObjectMapper.GetMapper().ConfigurationProvider)
            .ToList();

        var avgScore = items.Any() ? Math.Round(items.Average(x => x.Score), 2) : 0;
        double? currentUserFilmScore = null;
        string currentUserFilmReview = null;
        
        if (_currentUser.IsAuthenticated)
        {
            var currentUserReview = items.FirstOrDefault(x => x.Username == _currentUser.UserName);

            if (currentUserReview is not null)
            {
                currentUserFilmReview = currentUserReview.Review;
                currentUserFilmScore = currentUserReview.Score;
            }
        }

        return new FilmReviewsInfoDto
        {
            Reviews = items,
            AvgScore = avgScore,
            CurrentUserFilmScore = currentUserFilmScore,
            CurrentUserFilmReview = currentUserFilmReview
        };
    }

    [Authorize]
    public async Task<List<UserFilmReviewDto>> GetCurrentUserFilmReview()
    {
        var list = await Repository.GetQueryableAsync();

        var items = list
            .Where(x => x.UserId == _currentUser.Id)
            .ProjectTo<UserFilmReviewDto>(ObjectMapper.GetMapper().ConfigurationProvider)
            .ToList();

        return items;   
    }
}