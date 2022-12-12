using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Whatch.Enums;
using Whatch.Models;

namespace Whatch.Repositories;

public interface ISearchRepository : IRepository<Film>
{
    Task<List<Film>> SearchFilm(string key, FilmFilterType filterBy, int maxCount = 10);
}