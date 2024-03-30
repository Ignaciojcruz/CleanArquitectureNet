using AutoMapper;
using CleanArquitectureNet.Application.Features.Videos.Querys.GetVideosList;
using CleanArquitectureNet.Domain;

namespace CleanArquitectureNet.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Video, VideosVm>();
        }
    }
}
