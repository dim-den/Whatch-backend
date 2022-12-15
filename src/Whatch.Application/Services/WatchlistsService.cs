using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Users;
using Whatch.Dto;
using Whatch.Models;

namespace Whatch.Services;

public class WatchlistService : WhatchAppService, IWatchlistService
{
    private readonly IRepository<Watchlist, int> _repository;
    private readonly ICurrentUser _currentUser;

    public WatchlistService(IRepository<Watchlist, int> repository, ICurrentUser currentUser)
    {
        _repository = repository;
        _currentUser = currentUser;
    }

    [Authorize]
    public async Task<int> PostUpdateOrDeleteFromList([Required] int filmId)
    {
        var list = await _repository.GetQueryableAsync();

        var existing = list
            .FirstOrDefault(x => x.FilmId == filmId && x.UserId == _currentUser.Id);

        if (existing is null)
        {
            existing = new Watchlist()
            {
                UserId = (Guid)_currentUser.Id!,
                FilmId = filmId
            };
            await _repository.InsertAsync(existing);
        }
        else
        {
            await _repository.DeleteAsync(existing.Id);
        }
        return existing.Id;
    }

    [Authorize]
    public async Task<List<UserWatchlistDto>> GetUserWatchlist()
    {
        var list = await _repository.GetQueryableAsync();

        var items = list
            .Where(x => x.UserId == _currentUser.Id)
            .ProjectTo<UserWatchlistDto>(ObjectMapper.GetMapper().ConfigurationProvider)
            .ToList();

        return items;
    }

    [Authorize]
    public async Task<UserWatchlistDto> GetUserWatchlistForFilm([Required] int filmId)
    {
        var list = await _repository.GetQueryableAsync();

        var item = list
            .Where(x => x.UserId == _currentUser.Id && x.FilmId == filmId)
            .ProjectTo<UserWatchlistDto>(ObjectMapper.GetMapper().ConfigurationProvider)
            .FirstOrDefault();

        return item;
    }
}