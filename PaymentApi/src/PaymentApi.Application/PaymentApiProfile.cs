using AutoMapper;
using PaymentApi.Application.Dto;
using PaymentApi.Domain;

namespace PaymentApi.Application
{
    public class PaymentApiProfile : Profile
    {
        public PaymentApiProfile()
        {
            CreateMap<Sale, SaleDto>().ReverseMap();
            CreateMap<Item, ItemDto>().ReverseMap();
            CreateMap<Seller, SellerDto>().ReverseMap();
            CreateMap<CreateSaleDto, Sale>().ReverseMap();
        }
    }
}
