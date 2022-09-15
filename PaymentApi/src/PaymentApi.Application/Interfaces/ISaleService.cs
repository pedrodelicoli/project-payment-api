using PaymentApi.Application.Dto;
using PaymentApi.Domain;

namespace PaymentApi.Application.Interfaces
{
    public interface ISaleService
    {
        SaleDto Create(CreateSaleDto sale);

        SaleDto GetById(int id);

        SaleDto Update(int id, UpdateSaleDto updateSaleDto);

    }
}
