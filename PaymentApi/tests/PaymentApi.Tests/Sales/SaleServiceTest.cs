using System;

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
            Seller seller = new("376628533809", "Pedro", "pedro@delicoli.com", "18998244525");
            List<Item> itens = new()
            {
                new Item("Carteira", 2)
            };
            Sale sale = new(DateTime.Now, SaleStatus.AguardandoPagamento, seller, itens);

            saleRepositoryMock.Setup((s) => s.Create(sale)).Returns(sale);

            Sale result = saleService.Create(sale);

            result.Should().BeEquivalentTo(sale);
            saleRepositoryMock.Verify((s) => s.Create(It.IsAny<Sale>()), Times.Once);
        }

        [Fact]
        public void ShouldGetSaleById()
        {
            Seller seller = new("376628533809", "Pedro", "pedro@delicoli.com", "18998244525");
            List<Item> itens = new()
            {
                new Item("Carteira", 2)
            };
            Sale sale = new(DateTime.Now, SaleStatus.AguardandoPagamento, seller, itens);

            saleRepositoryMock.Setup((s) => s.GetById(It.IsAny<int>())).Returns(sale);


            Sale result = saleService.GetById(1);

            result.Should().BeEquivalentTo(sale);
            saleRepositoryMock.Verify((s) => s.GetById(It.IsAny<int>()), Times.Once);
        }

        [Theory]
        [InlineData(SaleStatus.PagamentoAprovado)]
        [InlineData(SaleStatus.Cancelada)]
        public void ShouldUpdateSaleStatus_WhenCurrentStatusAguardadandoPagamento(SaleStatus saleStatus)
        {
            Seller seller = new("376628533809", "Pedro", "pedro@delicoli.com", "18998244525");
            List<Item> itens = new()
            {
                new Item("Carteira", 2)
            };
            Sale sale = new(DateTime.Now, SaleStatus.AguardandoPagamento, seller, itens);

            saleRepositoryMock.Setup((s) => s.GetById(It.IsAny<int>())).Returns(sale);

            Sale updatedSale = new(DateTime.Now, saleStatus, seller, itens);

            saleRepositoryMock.Setup((s) => s.Update(It.IsAny<Sale>())).Returns(updatedSale);

            Sale result = saleService.Update(1, saleStatus);

            result.Should().BeEquivalentTo(updatedSale);
            saleRepositoryMock.Verify((s) => s.GetById(It.IsAny<int>()), Times.Once);
            saleRepositoryMock.Verify((s) => s.Update(It.IsAny<Sale>()), Times.Once);
        }

        [Theory]
        [InlineData(SaleStatus.EnviadoTransportadora)]
        [InlineData(SaleStatus.Entregue)]
        public void ShouldThrowsException_WhenTryUpdateCurrentStatusAguardadandoPagamento(SaleStatus saleStatus)
        {
            Seller seller = new("376628533809", "Pedro", "pedro@delicoli.com", "18998244525");
            List<Item> itens = new()
            {
                new Item("Carteira", 2)
            };
            Sale sale = new(DateTime.Now, SaleStatus.AguardandoPagamento, seller, itens);

            saleRepositoryMock.Setup((s) => s.GetById(It.IsAny<int>())).Returns(sale);

            Sale updatedSale = new(DateTime.Now, saleStatus, seller, itens);

            saleRepositoryMock.Setup((s) => s.Update(It.IsAny<Sale>())).Returns(updatedSale);
             
            Assert.Throws<Exception>(() => saleService.Update(1, saleStatus))
                .Message.Should().Be($"Não é permitido atualizar de Aguardando Pagamento para {saleStatus}");
        }

        [Theory]
        [InlineData(SaleStatus.EnviadoTransportadora)]
        [InlineData(SaleStatus.Cancelada)]
        public void ShouldUpdateSaleStatus_WhenCurrentStatusPagamentoAprovado(SaleStatus saleStatus)
        {
            Seller seller = new("376628533809", "Pedro", "pedro@delicoli.com", "18998244525");
            List<Item> itens = new()
            {
                new Item("Carteira", 2)
            };
            Sale sale = new(DateTime.Now, SaleStatus.PagamentoAprovado, seller, itens);

            saleRepositoryMock.Setup((s) => s.GetById(It.IsAny<int>())).Returns(sale);

            Sale updatedSale = new(DateTime.Now, saleStatus, seller, itens);

            saleRepositoryMock.Setup((s) => s.Update(It.IsAny<Sale>())).Returns(updatedSale);

            Sale result = saleService.Update(1, saleStatus);

            result.Should().BeEquivalentTo(updatedSale);
            saleRepositoryMock.Verify((s) => s.GetById(It.IsAny<int>()), Times.Once);
            saleRepositoryMock.Verify((s) => s.Update(It.IsAny<Sale>()), Times.Once);
        }

        [Theory]
        [InlineData(SaleStatus.Entregue)]
        [InlineData(SaleStatus.AguardandoPagamento)]
        public void ShouldThrowsException_WhenTryUpdateCurrentStatusPagamentoAprovado(SaleStatus saleStatus)
        {
            Seller seller = new("376628533809", "Pedro", "pedro@delicoli.com", "18998244525");
            List<Item> itens = new()
            {
                new Item("Carteira", 2)
            };
            Sale sale = new(DateTime.Now, SaleStatus.PagamentoAprovado, seller, itens);

            saleRepositoryMock.Setup((s) => s.GetById(It.IsAny<int>())).Returns(sale);

            Sale updatedSale = new(DateTime.Now, saleStatus, seller, itens);

            saleRepositoryMock.Setup((s) => s.Update(It.IsAny<Sale>())).Returns(updatedSale);

            Assert.Throws<Exception>(() => saleService.Update(1, saleStatus))
                .Message.Should().Be($"Não é permitido atualizar de Pagamento Aprovado para {saleStatus}");
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

            public Sale Update(int id, SaleStatus saleStatus)
            {                
                Sale sale = saleRepository.GetById(id);
                sale.UpdateStatus(saleStatus);
                return saleRepository.Update(sale);
            }            
        }

        public interface ISaleService
        {
            Sale Create(Sale sale);

            Sale GetById(int id);

            Sale Update(int id, SaleStatus saleStatus);

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
