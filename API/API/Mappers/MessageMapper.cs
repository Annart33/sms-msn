using System;
using API.DTO;
using AutoMapper;

namespace API.MapperProfiles
{
    public class MessageMapper : Profile
    {
        public MessageMapper()
        {
            CreateMap<MessageRequest, Message>()
                .ForMember(o => o.Date, dest => dest.MapFrom(x => DateTime.UtcNow));
        }
    }
}