using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Whatch.Models;
using Whatch.Repositories;

namespace Whatch.EntityFrameworkCore.Repositories;

public class EfCoreFilmReviewRepository : EfCoreRepository<WhatchDbContext, FilmReview, int>, IFilmReviewRepository
{
    public EfCoreFilmReviewRepository(IDbContextProvider<WhatchDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<int> LeaveReview(Guid userId, int filmId, int score, string review = null)
    {
        var context = await GetDbContextAsync();

        var film = await context.Films.Where(x => x.Id == filmId).FirstOrDefaultAsync(CancellationTokenProvider.Token);
        var user = await context.Users.Where(x => x.Id == userId).FirstOrDefaultAsync(CancellationTokenProvider.Token);

        Check.NotNull(film, nameof(film), WhatchDomainErrorCodes.NotValidUserOfFilm);
        Check.NotNull(user, nameof(user), WhatchDomainErrorCodes.NotValidUserOfFilm);
        
        var filmReview = new FilmReview
        {
            Score = score,
            Review = review,
            FilmId = film!.Id,
            UserId = user!.Id
        };

        context.FilmReviews.Add(filmReview);

        await context.SaveChangesAsync(CancellationTokenProvider.Token);

        return filmReview.Id;
    }

    public async Task<double?> GetFilmAvgScore(int filmId)
    {
        var context = await GetDbContextAsync();

        return await context.FilmReviews.Where(x => x.FilmId == filmId)
            .AverageAsync(x => x.Score);
    }
}