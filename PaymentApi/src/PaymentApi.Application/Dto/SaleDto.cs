using PaymentApi.Domain;
using PaymentApi.Domain.Exceptions;

namespace PaymentApi.Application.Dto
{
    public class SaleDto
    {
        public int Id { get; set; }
        public DateTime SaleTime { get; set; }
        public SaleStatus Status { get; set; }
        public SellerDto Seller { get; set; }
        public List<ItemDto> Itens { get; set; }

        public SaleDto(int id, DateTime saleTime, SaleStatus status, SellerDto seller, List<ItemDto> itens)
        {
            Id = id;
            SaleTime = saleTime;
            Status = status;
            Seller = seller;
            Itens = itens;
        }

        public SaleDto()
        {

        }
    }
}
