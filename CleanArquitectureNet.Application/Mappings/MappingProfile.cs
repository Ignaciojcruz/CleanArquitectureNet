using AutoMapper;
using CleanArquitectureNet.Application.Features.Directors.Commands.CreateDirector;
using CleanArquitectureNet.Application.Features.Directors.Commands.UpdateDirector;
using CleanArquitectureNet.Application.Features.Directors.Queries.GetDirectorsList;
using CleanArquitectureNet.Application.Features.Streamers.Commands.CreateStreamer;
using CleanArquitectureNet.Application.Features.Streamers.Commands.UpdateStreamer;
using CleanArquitectureNet.Application.Features.Streamers.Queries.GetStreamersList;
using CleanArquitectureNet.Application.Features.Videos.Queries.GetVideosList;
using CleanArquitectureNet.Domain;

namespace CleanArquitectureNet.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Video, VideosVm>();
            CreateMap<Director, DirectorsVm>();
            CreateMap<Streamer, StreamersVm>();
            CreateMap<CreateStreamerCommand, Streamer>();
            CreateMap<UpdateStreamerCommand, Streamer>();
            CreateMap<CreateDirectorCommand, Director>();
            CreateMap<UpdateDirectorCommand, Director>();
            
        }
    }
}
