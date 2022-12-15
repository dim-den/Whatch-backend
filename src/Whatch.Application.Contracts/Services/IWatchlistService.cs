using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Whatch.Dto;

namespace Whatch.Services;

public interface IWatchlistService : IApplicationService
{
    Task<int> PostUpdateOrDeleteFromList(int filmId);
    Task<List<UserWatchlistDto>> GetUserWatchlist();
    Task<UserWatchlistDto> GetUserWatchlistForFilm(int filmId);
}