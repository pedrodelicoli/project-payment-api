using PaymentApi.Domain;
using PaymentApi.Domain.Exceptions;

namespace PaymentApi.Application.Dto
{
    public class CreateSaleDto
    {
        public DateTime SaleTime { get; set; }
        public SellerDto Seller { get; set; }
        public List<ItemDto> Itens { get; set; }

        public CreateSaleDto(DateTime saleTime, SellerDto seller, List<ItemDto> itens)
        {
            SaleTime = saleTime;
            Seller = seller;
            Itens = itens;
        }

        public CreateSaleDto()
        {

        }
    }
}
