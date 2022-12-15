using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Whatch.Models;

namespace Whatch.Repositories;

public interface IFilmReviewRepository : IRepository<FilmReview, int>
{
    Task<int> LeaveReview(Guid userId, int filmId, int score, string review = null);
    Task<double?> GetFilmAvgScore(int filmId);
}