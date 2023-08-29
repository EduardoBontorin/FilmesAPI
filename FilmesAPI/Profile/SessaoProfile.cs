using AutoMapper;
using FilmesAPI.Data.Dto;
using FilmesAPI.Models;

namespace FilmesApi.Profiles;

public class SessaoProfile : Profile
{
    public SessaoProfile()
    {
        CreateMap<CreateSessaoDto, Sessao>();
        CreateMap<Sessao, ReadSessaoDto>();
      


    }
}