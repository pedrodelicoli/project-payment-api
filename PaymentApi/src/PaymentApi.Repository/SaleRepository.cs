using Microsoft.EntityFrameworkCore;
using PaymentApi.Domain;
using PaymentApi.Repository.Interfaces;

namespace PaymentApi.Repository
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DataBaseContext dataBaseContext;
        public SaleRepository(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }
        public Sale Create(Sale sale)
        {
            var createdSale = dataBaseContext.Add(sale);
            dataBaseContext.SaveChanges();
            return createdSale.Entity;
        }

        public Sale GetById(int id)
        {
            return dataBaseContext.Sales.Include((s) => s.Seller)
                .Include((s) => s.Itens).Where(s => s.Id == id).FirstOrDefault();
        }

        public Sale Update(Sale sale)
        {
            var updatedSale = dataBaseContext.Update(sale);
            dataBaseContext.SaveChanges();
            return updatedSale.Entity;
        }
    }
}