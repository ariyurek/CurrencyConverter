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
            CreateMap<Currency, CurrencyPrice>().ReverseMap();
            CreateMap<Currency, AddCoinPriceCommand>().ReverseMap();
        }
    }
}
