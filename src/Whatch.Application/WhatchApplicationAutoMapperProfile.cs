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
        
        CreateMap<FilmCast, FilmCastDto>();
        CreateMap<CreateUpdateFilmCastDto, FilmCast>();
    }
}
