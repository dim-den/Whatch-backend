using System.Linq;
using AutoMapper;
using Whatch.Dto;
using Whatch.Models;

namespace Whatch;

public class WhatchApplicationAutoMapperProfile : Profile
{
    public WhatchApplicationAutoMapperProfile()
    {
        CreateMap<Film, FilmDto>();
        CreateMap<Film, FilmSearchDto>()
            .ForMember(x => x.Actors, _ => _.MapFrom(x => x.Casts.Select(y => y.Actor)));
        CreateMap<Film, FilmWithScoreDto>()
            .ForMember(x => x.AvgScore, _ => _.Ignore());
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
            .ForMember(x => x.Actor, _ => _.MapFrom(x => x.Actor));

        CreateMap<Watchlist, UserWatchlistDto>()
            .ForMember(x => x.Film, _ => _.MapFrom(x => x.Film));
    }
}
