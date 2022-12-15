using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;
using Whatch.Dto;
using Whatch.Models;
using Whatch.Permissions;
using Whatch.Repositories;

namespace Whatch.Services;

public class FilmService : CrudAppService<Film, FilmDto, int, PagedAndSortedResultRequestDto, CreateUpdateFilmDto>, IFilmService
{
    private readonly IFilmRepository _filmRepository;
    private readonly IFilmReviewRepository _filmReviewRepository;
    private readonly ICurrentUser _currentUser;

    public FilmService(IRepository<Film, int> repository, IFilmRepository filmRepository, ICurrentUser currentUser, IFilmReviewRepository filmReviewRepository) : base(repository)
    {
        _filmRepository = filmRepository;
        _currentUser = currentUser;
        _filmReviewRepository = filmReviewRepository;
        CreatePolicyName = WhatchPermissions.CrudOperations;
        DeletePolicyName = WhatchPermissions.CrudOperations;
        UpdatePolicyName = WhatchPermissions.CrudOperations;
    }

    [Authorize]
    public async Task<List<FilmWithScoreDto>> GetUserRecommendationFilms()
    {
        var films = await _filmRepository.GetUserFilmRecommendations((Guid)_currentUser.Id!);
        
        var results = ObjectMapper.Map<List<Film>, List<FilmWithScoreDto>>(films);

        foreach (var result in results)
        {
            result.AvgScore = await _filmReviewRepository.GetFilmAvgScore(result.Id);
        }

        return results;
    }
}