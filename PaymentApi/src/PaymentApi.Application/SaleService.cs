using PaymentApi.Application.Interfaces;
using PaymentApi.Domain;
using PaymentApi.Repository.Interfaces;

namespace PaymentApi.Application
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository saleRepository;

        public SaleService(ISaleRepository saleRepository)
        {
            this.saleRepository = saleRepository;
        }

        public Sale Create(Sale sale) => saleRepository.Create(sale);

        public Sale GetById(int id) => saleRepository.GetById(id);

        public Sale Update(int id, SaleStatus saleStatus)
        {
            Sale sale = saleRepository.GetById(id);
            sale.UpdateStatus(saleStatus);
            return saleRepository.Update(sale);
        }
    }
}