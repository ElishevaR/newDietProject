using AutoMapper;
using Core.DTO;
using Data.Model;

namespace WebApi.Config
{
    public class Profiler : Profile
    {
        public Profiler()
        {
            CreateMap<SubscriberDTO, Subscriber>().ReverseMap();
            CreateMap<Subscriber, SubscriberDTO>().ReverseMap();
        }

    }
}
