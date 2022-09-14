namespace PaymentApi.Tests.Sales
{
    public class SaleServiceTest
    {
        private readonly SaleService saleService;
        private readonly Mock<ISaleRepository> saleRepositoryMock;
        public SaleServiceTest()
        {
            saleRepositoryMock = new Mock<ISaleRepository>();
            saleService = new(saleRepositoryMock.Object);
        }

        [Fact]
        public void ShouldAddSale()
        {
            Seller seller = new(1, "376628533809", "Pedro", "pedro@delicoli.com", "18998244525");
            List<Item> itens = new()
            {
                new Item(1, "Carteira", 2)
            };
            Sale sale = new(1, DateTime.Now, SaleStatus.AguardandoPagamento, seller, itens);

            saleRepositoryMock.Setup((s) => s.Create(sale)).Returns(sale);

            Sale result = saleService.Create(sale);

            result.Should().BeEquivalentTo(sale);
            saleRepositoryMock.Verify((s) => s.Create(It.IsAny<Sale>()), Times.Once);
        }

        public class SaleService : ISaleService
        {
            private readonly ISaleRepository saleRepository;

            public SaleService(ISaleRepository saleRepository)
            {
                this.saleRepository = saleRepository;
            }

            public Sale Create(Sale sale) => saleRepository.Create(sale);

            public Sale GetById(int id) => saleRepository.GetById(id);

            public Sale Update(Sale sale) => saleRepository.Update(sale);
        }

        public interface ISaleService
        {
            Sale Create(Sale sale);

            Sale GetById(int id);

            Sale Update(Sale sale);

        }

        public class SaleRepository : ISaleRepository
        {
            public Sale Create(Sale sale)
            {
                throw new NotImplementedException();
            }

            public Sale GetById(int id)
            {
                throw new NotImplementedException();
            }

            public Sale Update(Sale sale)
            {
                throw new NotImplementedException();
            }
        }

        public interface ISaleRepository
        {
            Sale Create(Sale sale);

            Sale GetById(int id);

            Sale Update(Sale sale);
        }
    }
}
