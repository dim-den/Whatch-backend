using AutoMapper;
using Whatch.Dto;
using Whatch.Models;

namespace Whatch;

public class WhatchApplicationAutoMapperProfile : Profile
{
    public WhatchApplicationAutoMapperProfile()
    {
        CreateMap<Film, FilmDto>();
        CreateMap<CreateUpdateFilmDto, Film>();
        
        CreateMap<Actor, ActorDto>();
        CreateMap<CreateUpdateActorDto, Actor>();
        
        CreateMap<FilmReview, FilmReviewDto>();
        CreateMap<FilmReview, FilmReviewsInfoDto>();
        CreateMap<FilmReview, FilmReviewInfoDto>()
            .ForMember(x => x.Username, _ => _.MapFrom(x => x.User.UserName));
        CreateMap<CreateUpdateFilmReviewDto, FilmReview>();
        CreateMap<FilmReview, UserFilmReviewDto>()
            .ForMember(x => x.Film, _ => _.MapFrom(x => x.Film));
        
        CreateMap<FilmCast, FilmCastDto>();
        CreateMap<CreateUpdateFilmCastDto, FilmCast>();
        CreateMap<FilmCast, FilmCastInfoDto>()
            .ForMember(x => x.Birthday, _ => _.MapFrom(x => x.Actor.Birthday))
            .ForMember(x => x.Name, _ => _.MapFrom(x => x.Actor.Name))
            .ForMember(x => x.Lastname, _ => _.MapFrom(x => x.Actor.Lastname))
            .ForMember(x => x.Country, _ => _.MapFrom(x => x.Actor.Country));

        CreateMap<Watchlist, UserWatchlistDto>()
            .ForMember(x => x.Film, _ => _.MapFrom(x => x.Film));
    }
}
