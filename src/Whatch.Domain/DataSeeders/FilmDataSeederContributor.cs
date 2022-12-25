using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Whatch.Enums;
using Whatch.Models;

namespace Whatch.DataSeeders;

public class FilmDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<FilmCast, int> _filmCastRepository;
    private readonly IRepository<Actor, int> _actorRepository;
    private readonly IRepository<Film, int> _filmRepository;

    public FilmDataSeederContributor(IRepository<FilmCast, int> filmCastRepository, IRepository<Actor, int> actorRepository, IRepository<Film, int> filmRepository)
    {
        _filmCastRepository = filmCastRepository;
        _actorRepository = actorRepository;
        _filmRepository = filmRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        var films = GetFilms();
        var actors = GetActors();
        var casts = GetFilmCasts(films, actors);
        
        await _filmCastRepository.InsertManyAsync(casts);
    }

    private List<FilmCast> GetFilmCasts(List<Film> films, List<Actor> actors)
    {
        var casts = new List<FilmCast>();

        casts.Add(new()
        {
            RoleName = "Andrew",
            Film = films.First(x => x.Title.StartsWith("Bicentennial")),
            Actor = actors.First(x => x.Lastname.StartsWith("Williams"))
        });
        
        casts.Add(new()
        {
            RoleName = "Little Miss",
            Film = films.First(x => x.Title.StartsWith("Bicentennial")),
            Actor = actors.First(x => x.Lastname.StartsWith("Davidtz"))
        });
         
        casts.Add(new()
        {
            RoleName = "John Milton",
            Film = films.First(x => x.Title.StartsWith("The Devil")),
            Actor = actors.First(x => x.Lastname.StartsWith("Pacino"))
        });
        
        casts.Add(new()
        {   
            RoleName = "Kevin Lomax",
            Film = films.First(x => x.Title.StartsWith("The Devil")),
            Actor = actors.First(x => x.Lastname.StartsWith("Reeves"))
        });
        
        casts.Add(new()
        {   
            RoleName = "Jordan Belfort",
            Film = films.First(x => x.Title.StartsWith("The Wolf of ")),
            ActorId = 1
        });
        
        casts.Add(new()
        {   
            RoleName = "Donnie Azoff",
            Film = films.First(x => x.Title.StartsWith("The Wolf of ")),
            Actor = actors.First(x => x.Lastname.StartsWith("Hill"))
        });  
        
        casts.Add(new()
        {   
            RoleName = "Naomi Lapaglia",
            Film = films.First(x => x.Title.StartsWith("The Wolf of ")),
            Actor = actors.First(x => x.Lastname.StartsWith("Robbie"))
        });
        
        casts.Add(new()
        {   
            RoleName = "Cobb",
            Film = films.First(x => x.Title.StartsWith("Inception")),
            ActorId = 1
        });
        
        casts.Add(new()
        {   
            RoleName = "Robert Fischer",
            Film = films.First(x => x.Title.StartsWith("Inception")),
            Actor = actors.First(x => x.Lastname.StartsWith("Murphy"))
        });
        
        return casts;
    }

    private List<Film> GetFilms()
    {
        var films = new List<Film>();
        
        films.Add(new()
        {
            Title = "Bicentennial Man",
            Description = "An android endeavors to become human as he gradually acquires emotions.",
            Country = "Germany, USA",
            Director = "Chris Columbus",
            Budget = 10000000,
            Fees = 87423861,
            ReleaseDate = DateTime.Parse("1999-12-17 00:00:00.000"),
            Genre = FilmGenre.Drama,
            TrailerUrl = "https://www.youtube.com/embed/z5YMEwX2-88"
        });  
        
        films.Add(new()
        {
            Title = "The Devil's Advocate",
            Description = "An exceptionally-adept Florida lawyer is offered a job at a high-end New York City law firm with a high-end boss--the biggest opportunity of his career to date.",
            Country = "Germany, USA",
            Director = "Taylor Hackford",
            Budget = 57000000,
            Fees = 153000000,
            ReleaseDate = DateTime.Parse("1997-10-11 00:00:00.000"),
            Genre = FilmGenre.Drama,
            TrailerUrl = "https://www.youtube.com/embed/40hHA9n4C2o"
        }); 
        
        films.Add(new()
        {
            Title = "The Wolf of Wall Street",
            Description = "Based on the true story of Jordan Belfort, from his rise to a wealthy stock-broker living the high life to his fall involving crime, corruption and the federal government.",
            Country = "USA",
            Director = "Martin Scorsese",
            Budget = 100000000,
            Fees = 405000000,
            ReleaseDate = new DateTime(2013, 12, 19),
            Genre = FilmGenre.Drama,
            TrailerUrl = "https://www.youtube.com/embed/iszwuX1AK6A"
        });
        
        films.Add(new()
        {
            Title = "Inception",
            Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O., but his tragic past may doom the project and his team to disaster.",
            Country = "USA",
            Director = "Christopher Nolan",
            Budget = 160000000,
            Fees = 830000000,
            ReleaseDate = new DateTime(2010, 7, 16),
            Genre = FilmGenre.ScienceFiction,
            TrailerUrl = "https://www.youtube.com/embed/YoHD9XEInc0"
        });

        return films;
    }
    
    private List<Actor> GetActors()
    {
        var actors = new List<Actor>();
        
        actors.Add(new()
        {
            Name = "Robin",
            Lastname = "Williams",
            Country = "USA",
            Birthday = DateTime.Parse("1951-11-21")
        });
        
        actors.Add(new()
        {
            Name = "Embeth",
            Lastname = "Davidtz",
            Country = "USA",
            Birthday = DateTime.Parse("1971-11-21")
        });
        
        actors.Add(new()
        {
            Name = "Keanu",
            Lastname = "Reeves",
            Country = "Lebanon",
            Birthday = new DateTime(1964, 9, 11)
        });
        
        actors.Add(new()
        {
            Name = "Al",
            Lastname = "Pacino",
            Country = "USA",
            Birthday = new DateTime(1940, 4, 25)
        });
        
        actors.Add(new()
        {
            Name = "Jonah",
            Lastname = "Hill",
            Country = "USA",
            Birthday = new DateTime(1983, 4, 20)
        });
        
        actors.Add(new()
        {
            Name = "Margot",
            Lastname = "Robbie",
            Country = "Australia",
            Birthday = new DateTime(1990, 7, 20)
        });
        
        actors.Add(new()
        {
            Name = "Cillian",
            Lastname = "Murphy",
            Country = "Ireland",
            Birthday = new DateTime(1973, 7, 20)
        });
        
        return actors;
    }

}
