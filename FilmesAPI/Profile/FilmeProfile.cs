using AutoMapper;
using FilmesAPI.Data.Dto;
using FilmesAPI.Models;

namespace FilmesApi.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDto, Filme>();
        CreateMap<Filme, ReadFilmeDto>()
            .ForMember(filmeDto => filmeDto.Sessoes,
            opt => opt.MapFrom(filme => filme.Sessoes));
        CreateMap<UpdateFilmeDto, Filme>();

        
    }
}