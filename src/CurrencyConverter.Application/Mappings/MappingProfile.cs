using AutoMapper;
using CurrencyConverter.Application.Features.Commands.AddCoinPrice;
using CurrencyConverter.Application.Features.Queries;
using CurrencyConverter.Domain.Entities;

namespace CurrencyConverter.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Quote, CurrencyPrice>().ReverseMap();
            CreateMap<Quote, AddCoinPriceCommand>().ReverseMap();
        }
    }
}
