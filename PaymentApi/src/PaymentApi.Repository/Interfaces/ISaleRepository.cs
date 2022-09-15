using PaymentApi.Domain;

namespace PaymentApi.Repository.Interfaces
{
    public interface ISaleRepository
    {
        Sale Create(Sale sale);

        Sale GetById(int id);

        Sale Update(Sale sale);
    }
}
