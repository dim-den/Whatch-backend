using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Whatch.Enums;
using Whatch.Models;
using Whatch.Repositories;

namespace Whatch.EntityFrameworkCore.Repositories;

public class EfCoreSearchRepository : EfCoreRepository<WhatchDbContext, Film>, ISearchRepository
{
    public EfCoreSearchRepository(IDbContextProvider<WhatchDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<List<Film>> SearchFilm([NotNull] string key, FilmFilterType filterBy, int maxCount = 10)
    {
        var context = await GetDbContextAsync();

        key ??= string.Empty;
        var genreParsed = Enum.TryParse<FilmGenre>(key, out var genre);
        
        if (filterBy is FilmFilterType.ByGenre && !genreParsed)
        {
            return new();
        }

        key = key.ToLower();
        
        var films = await context.Films.AsNoTracking()
            .Include(x => x.Casts)
                .ThenInclude(x => x.Actor)
            .WhereIf(filterBy == FilmFilterType.ByTitle,
                x => x.Title.ToLower().Contains(key))
            .WhereIf(filterBy == FilmFilterType.ByGenre,
                x => x.Genre == genre)
            .WhereIf(filterBy == FilmFilterType.ByActor,
                x => x.Casts.Select(y => y.Actor.Lastname).Any(a => a.ToLower().Contains(key)))
            .WhereIf(filterBy == FilmFilterType.AllFields && genreParsed ,
                x =>  x.Title.ToLower().Contains(key) 
                      || x.Genre == genre 
                      || x.Casts.Select(y => y.Actor.Lastname).Any(a => a.ToLower().Contains(key)))
            .WhereIf(filterBy == FilmFilterType.AllFields && !genreParsed ,
                x =>  x.Title.ToLower().Contains(key) || x.Casts.Select(y => y.Actor.Lastname).Any(a => a.ToLower().Contains(key)))
            .Take(maxCount)
            .ToListAsync();

        return films;

    }
}