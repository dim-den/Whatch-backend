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

        var missedFilms = films.Where(x => !casts.Any(y => y.Film.Title.StartsWith(x.Title)));
        var missedActors = actors.Where(x => !casts.Any(y => y.Actor.Lastname.StartsWith(x.Lastname)));

       // await _filmCastRepository.InsertManyAsync(casts);
        //await _filmRepository.InsertManyAsync(missedFilms);
        //await _actorRepository.InsertManyAsync(missedActors);
    }

    private List<FilmCast> GetFilmCasts(List<Film> films, List<Actor> actors)
    {
        var casts = new List<FilmCast>();

        casts.Add(new()
        {
            RoleName = "Nina Saires",
            Film = films.First(x => x.Title.StartsWith("Black Swan")),
            Actor = actors.First(x => x.Lastname.StartsWith("Portman"))
        });
        
        casts.Add(new()
        {
            RoleName = "Tomas Leroy",
            Film = films.First(x => x.Title.StartsWith("Black Swan")),
            Actor = actors.First(x => x.Lastname.StartsWith("Cassel"))
        });
        
        casts.Add(new()
        {
            RoleName = "Odillia",
            Film = films.First(x => x.Title.StartsWith("Black Swan")),
            Actor = actors.First(x => x.Lastname.StartsWith("Kunis"))
        });
        
        casts.Add(new()
        {
            RoleName = "Rik Dalton",
            Film = films.First(x => x.Title.StartsWith("Once")),
            Actor = actors.First(x => x.Lastname.StartsWith("DiCaprio"))
        });
        
        casts.Add(new()
        {
            RoleName = "Kliff Bout",
            Film = films.First(x => x.Title.StartsWith("Once")),
            Actor = actors.First(x => x.Lastname.StartsWith("Pitt"))
        });

        casts.Add(new()
        {
            RoleName = "Sharon Teight",
            Film = films.First(x => x.Title.StartsWith("Once")),
            Actor = actors.First(x => x.Lastname.StartsWith("Robbie"))
        });
        
        return casts;
    }

    private List<Film> GetFilms()
    {
        var films = new List<Film>();
        
        films.Add(new()
        {
            Title = "Black Swan",
            Description = "A committed dancer struggles to maintain her sanity after winning the lead role in a production of Tchaikovsky Swan Lake",
            Country = "USA",
            Director = "Darren Aronofsky",
            Budget = 13000000,
            Fees = 330000000,
            ReleaseDate = DateTime.Parse("2010-01-10 00:00:00.000"),
            Genre = FilmGenre.Thriller,
            TrailerUrl = "https://www.youtube.com/embed/5jaI1XOB-bs"
        });
        
        films.Add(new()
        {
            Title = "Once Upon a Time... in Hollywood",
            Description = "A faded television actor and his stunt double strive to achieve fame and success in the final years of Hollywood Golden Age in 1969 Los Angeles.",
            Country = "USA",
            Director = "Quentin Tarantino",
            Budget = 90000000,
            Fees = 370000000,
            ReleaseDate = DateTime.Parse("2019-08-07 03:00:00.000"),
            Genre = FilmGenre.Comedy,
            TrailerUrl = "https://www.youtube.com/embed/Rga4rp4j5TY"
        });
        
        films.Add(new()
        {
            Title = "The Green Mile",
            Description = "The lives of guards on Death Row are affected by one of their charges: a black man accused of child murder and rape, yet who has a mysterious gift",
            Country = "USA",
            Director = "James Cameron",
            Budget = 200000000,
            Fees = 639000000,
            ReleaseDate = DateTime.Parse("2000-04-18 03:00:00.000"),
            Genre = FilmGenre.Drama,
            TrailerUrl = "https://www.youtube.com/embed/Ki4haFrqSrw"
        });
        
        films.Add(new()
        {
            Title = "Titanic",
            Description = "A seventeen-year-old aristocrat falls in love with a kind but poor artist aboard the luxurious, ill-fated R.M.S. Titanic.",
            Country = "USA",
            Director = "James Cameron",
            Budget = 200000000,
            Fees = 60000000,
            ReleaseDate = DateTime.Parse("2000-04-18 03:00:00.000"),
            Genre = FilmGenre.Drama,
            TrailerUrl = "https://www.youtube.com/embed/cIJ8ma0kKtY"
        });
        
        films.Add(new()
        {
            Title = "Fight Club",
            Description = "An insomniac office worker and a devil-may-care soap maker form an underground fight club that evolves into much more.",
            Country = "USA, Germany",
            Director = "David Fincher",
            Budget = 60000000,
            Fees = 131560000,
            ReleaseDate = DateTime.Parse("2000-01-13 02:00:00.000"),
            Genre = FilmGenre.Drama,
            TrailerUrl = "https://www.youtube.com/embed/qtRKdVHc-cE"
        });

        return films;
    }
    
    private List<Actor> GetActors()
    {
        var actors = new List<Actor>();
        
        actors.Add(new()
        {
            Name = "Leonardo",
            Lastname = "DiCaprio",
            Country = "USA",
            Birthday = DateTime.Parse("1974-11-11")
        });
        
        actors.Add(new()
        {
            Name = "Brad",
            Lastname = "Pitt",
            Country = "USA",
            Birthday = DateTime.Parse("1963-11-18")
        });
        
        actors.Add(new()
        {
            Name = "Mila",
            Lastname = "Kunis",
            Country = "Ukraine",
            Birthday = DateTime.Parse("1983-08-14")
        });
        
        actors.Add(new()
        {
            Name = "Margot",
            Lastname = "Robbie",
            Country = "Australia",
            Birthday = DateTime.Parse("1990-07-05")
        });
        
        actors.Add(new()
        {
            Name = "Eva",
            Lastname = "Green",
            Country = "France",
            Birthday = DateTime.Parse("1980-07-06")
        });
        
        actors.Add(new()
        {
            Name = "Daniel",
            Lastname = "Craig",
            Country = "UK",
            Birthday = DateTime.Parse("1968-03-02")
        });
        
        actors.Add(new()
        {
            Name = "Natalie",
            Lastname = "Portman",
            Country = "Israel",
            Birthday = DateTime.Parse("1981-06-09")
        });
        
        actors.Add(new()
        {
            Name = "Vincent",
            Lastname = "Cassel",
            Country = "France",
            Birthday = DateTime.Parse("1966-11-23")
        });  
        
        actors.Add(new()
        {
            Name = "Will",
            Lastname = "Smith",
            Country = "USA",
            Birthday = DateTime.Parse("1968-09-25")
        });  
        
        actors.Add(new()
        {
            Name = "Bridget",
            Lastname = "Moynahan",
            Country = "USA",
            Birthday = DateTime.Parse("1971-09-28")
        });
        
        return actors;
    }

}
