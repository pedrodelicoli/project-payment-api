using PaymentApi.Domain;

namespace PaymentApi.Application.Dto
{
    public class CreateSaleDto
    {
        /// <summary>
        /// Data da Venda
        /// </summary>
        public DateTime? SaleTime { get; set; }

        /// <summary>
        /// Vendedor que realizou a venda
        /// </summary>
        public CreateSellerDto? Seller { get; set; }

        /// <summary>
        /// Itens que foram vendidos
        /// </summary>
        public List<CreateItemDto>? Itens { get; set; }

        public CreateSaleDto(DateTime saleTime, CreateSellerDto seller, List<CreateItemDto> itens)
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
