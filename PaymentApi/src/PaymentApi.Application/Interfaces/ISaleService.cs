using PaymentApi.Domain;

namespace PaymentApi.Application.Interfaces
{
    public interface ISaleService
    {
        Sale Create(Sale sale);

        Sale GetById(int id);

        Sale Update(int id, SaleStatus saleStatus);

    }
}
