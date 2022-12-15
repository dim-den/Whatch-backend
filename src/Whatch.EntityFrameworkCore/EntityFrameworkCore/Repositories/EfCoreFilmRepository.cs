using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Whatch.Enums;
using Whatch.Models;
using Whatch.Repositories;

namespace Whatch.EntityFrameworkCore.Repositories;

public class EfCoreFilmRepository : EfCoreRepository<WhatchDbContext, Film>, IFilmRepository
{
    private WhatchDbContext _context;

    public EfCoreFilmRepository(IDbContextProvider<WhatchDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<List<Film>> GetUserFilmRecommendations(Guid userId)
    {
        _context = await GetDbContextAsync();

        var userFavourites = await GetUserFavouriteGenres(userId);
        if (!userFavourites.Any())
        {
            userFavourites = GetRandomGenres();
        }

        List<Film> recommended = new();
        for (int i = 0; i < userFavourites.Take(3).Count(); i++)
        {
            var res = await GetBestFilmsOfGenre(userFavourites[i], (3 - i) * 5);
            recommended.AddRange(res);
        }
        
        return recommended.Shuffle().Take(5).ToList();
    }

    private async Task<List<FilmGenre>> GetUserFavouriteGenres(Guid userId)
    {
        var result = await _context.FilmReviews.AsNoTracking()
            .Where(x => x.UserId == userId)
            .Select(x => new
            {
                x.Film.Genre,
                x.Score
            })
            .GroupBy(x => x.Genre, (genre, scores) => new
            {
                genre,
                avgScore = scores.Average(x => x.Score)
            })
            .ToListAsync();

        return result.OrderByDescending(x => x.avgScore).Select(x => x.genre).ToList();
    }

    private async Task<List<Film>> GetBestFilmsOfGenre(FilmGenre genre, int count)
    {
        var result = await _context.Films.AsNoTracking()
            .Where(x => x.Genre == genre)
            .Select(x => new
            {
                film = x,
                avgScore = x.Reviews.Average(y => y.Score)
            })
            .OrderByDescending(x => x.avgScore)
            .Take(count)
            .ToListAsync();

        return result.Select(x => x.film).ToList();
    }

    private List<FilmGenre> GetRandomGenres(int count = 3)
    {
        return Enumerable.Range((int)FilmGenre.Action, (int)FilmGenre.Western)
            .Shuffle()
            .Take(count)
            .Select(x => (FilmGenre)x)
            .ToList();
    }
}

public static class ListExtensions
{
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> items)
    {
        return items.OrderBy(_ => Guid.NewGuid());
    }
}