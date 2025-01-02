using AutoMapper;
using MultiShop.Message.DAL.Entities;
using MultiShop.Message.Dtos;

namespace MultiShop.Message.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping() 
        {
            CreateMap<UserMessage , CreateMessageDto>().ReverseMap();
            CreateMap<UserMessage , UpdateMessageDto>().ReverseMap();
            CreateMap<UserMessage , ResultInboxMessageDto>().ReverseMap();
            CreateMap<UserMessage , ResultMessageDto>().ReverseMap();
            CreateMap<UserMessage , ResultSendboxMessageDto>().ReverseMap();
            CreateMap<UserMessage , GetByIdMessageDto>().ReverseMap();
        }
    }
}
