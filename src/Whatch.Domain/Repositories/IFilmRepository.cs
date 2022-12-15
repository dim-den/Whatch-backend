using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Whatch.Models;

namespace Whatch.Repositories;

public interface IFilmRepository
{
    Task<List<Film>> GetUserFilmRecommendations(Guid userId);
}