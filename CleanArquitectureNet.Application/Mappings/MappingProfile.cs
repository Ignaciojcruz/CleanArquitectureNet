using AutoMapper;
using CleanArquitectureNet.Application.Features.Streamers.Commands.CreateStreamer;
using CleanArquitectureNet.Application.Features.Videos.Queries.GetVideosList;
using CleanArquitectureNet.Domain;

namespace CleanArquitectureNet.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Video, VideosVm>();
            CreateMap<CreateStreamerCommand, Streamer>();
        }
    }
}
