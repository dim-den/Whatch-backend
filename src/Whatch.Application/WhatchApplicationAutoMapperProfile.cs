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
        CreateMap<LeaveReviewDto, FilmReview>();
        
        CreateMap<FilmCast, FilmCastDto>();
        CreateMap<CreateUpdateFilmCastDto, FilmCast>();
    }
}
