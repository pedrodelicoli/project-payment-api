using PaymentApi.Domain.Exceptions;
using System;

namespace PaymentApi.Tests.Sales
{
    public class SaleServiceTest
    {
        private readonly SaleService saleService;
        private readonly Mock<ISaleRepository> saleRepositoryMock;

        private Seller seller;
        private List<Item> itens;
        private Sale sale;
        public SaleServiceTest()
        {
            saleRepositoryMock = new Mock<ISaleRepository>();
            saleService = new(saleRepositoryMock.Object);
            seller = new("376628533809", "Pedro", "pedro@delicoli.com", "18998244525");
            itens = new()
            {
                new Item("Carteira", 2)
            };
            sale = new(DateTime.Now, SaleStatus.AguardandoPagamento, seller, itens);
        }

        [Fact]
        public void ShouldAddSale()
        {
            saleRepositoryMock.Setup((s) => s.Create(sale)).Returns(sale);

            Sale result = saleService.Create(sale);

            result.Should().BeEquivalentTo(sale);
            saleRepositoryMock.Verify((s) => s.Create(It.IsAny<Sale>()), Times.Once);
        }

        [Fact]
        public void ShouldGetSaleById()
        {            
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
            Sale saleTest = new(DateTime.Now, SaleStatus.AguardandoPagamento, seller, itens);

            saleRepositoryMock.Setup((s) => s.GetById(It.IsAny<int>())).Returns(saleTest);

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
            Sale saleTest = new(DateTime.Now, SaleStatus.AguardandoPagamento, seller, itens);

            saleRepositoryMock.Setup((s) => s.GetById(It.IsAny<int>())).Returns(saleTest);

            Sale updatedSale = new(DateTime.Now, saleStatus, seller, itens);

            saleRepositoryMock.Setup((s) => s.Update(It.IsAny<Sale>())).Returns(updatedSale);
             
            Assert.Throws<Exception>(() => saleService.Update(1, saleStatus))
                .Message.Should().Be(string.Format(ErrorMessage.errorAguardandoPagamento, saleStatus));
        }

        [Theory]
        [InlineData(SaleStatus.EnviadoTransportadora)]
        [InlineData(SaleStatus.Cancelada)]
        public void ShouldUpdateSaleStatus_WhenCurrentStatusPagamentoAprovado(SaleStatus saleStatus)
        {
            Sale saleTest = new(DateTime.Now, SaleStatus.PagamentoAprovado, seller, itens);

            saleRepositoryMock.Setup((s) => s.GetById(It.IsAny<int>())).Returns(saleTest);

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
            Sale saleTest = new(DateTime.Now, SaleStatus.PagamentoAprovado, seller, itens);

            saleRepositoryMock.Setup((s) => s.GetById(It.IsAny<int>())).Returns(saleTest);

            Sale updatedSale = new(DateTime.Now, saleStatus, seller, itens);

            saleRepositoryMock.Setup((s) => s.Update(It.IsAny<Sale>())).Returns(updatedSale);

            Assert.Throws<Exception>(() => saleService.Update(1, saleStatus))
                .Message.Should().Be(string.Format(ErrorMessage.errorPagamentoAprovado, saleStatus));
        }

        [Fact]        
        public void ShouldUpdateSaleStatus_WhenCurrentStatusEnviadoTransportador()
        {
            Sale saleTest = new(DateTime.Now, SaleStatus.EnviadoTransportadora, seller, itens);

            saleRepositoryMock.Setup((s) => s.GetById(It.IsAny<int>())).Returns(saleTest);

            Sale updatedSale = new(DateTime.Now, SaleStatus.Entregue, seller, itens);

            saleRepositoryMock.Setup((s) => s.Update(It.IsAny<Sale>())).Returns(updatedSale);

            Sale result = saleService.Update(1, SaleStatus.Entregue);

            result.Should().BeEquivalentTo(updatedSale);
            saleRepositoryMock.Verify((s) => s.GetById(It.IsAny<int>()), Times.Once);
            saleRepositoryMock.Verify((s) => s.Update(It.IsAny<Sale>()), Times.Once);
        }

        [Theory]
        [InlineData(SaleStatus.AguardandoPagamento)]
        [InlineData(SaleStatus.PagamentoAprovado)]
        [InlineData(SaleStatus.Cancelada)]
        public void ShouldThrowsException_WhenTryUpdateCurrentStatusEnviadoTransportador(SaleStatus saleStatus)
        {            
            Sale saleTest = new(DateTime.Now, SaleStatus.EnviadoTransportadora, seller, itens);

            saleRepositoryMock.Setup((s) => s.GetById(It.IsAny<int>())).Returns(saleTest);

            Sale updatedSale = new(DateTime.Now, saleStatus, seller, itens);

            saleRepositoryMock.Setup((s) => s.Update(It.IsAny<Sale>())).Returns(updatedSale);

            Assert.Throws<Exception>(() => saleService.Update(1, saleStatus))
                .Message.Should().Be(string.Format(ErrorMessage.errorEnviadoTransportadora, saleStatus));
        }

        [Theory]
        [InlineData(SaleStatus.AguardandoPagamento)]
        [InlineData(SaleStatus.PagamentoAprovado)]
        [InlineData(SaleStatus.EnviadoTransportadora)]
        [InlineData(SaleStatus.Entregue)]
        public void ShouldThrowsException_WhenTryUpdateCurrentStatusCancelada(SaleStatus saleStatus)
        {
            Sale saleTest = new(DateTime.Now, SaleStatus.Cancelada, seller, itens);

            saleRepositoryMock.Setup((s) => s.GetById(It.IsAny<int>())).Returns(saleTest);

            Sale updatedSale = new(DateTime.Now, saleStatus, seller, itens);

            saleRepositoryMock.Setup((s) => s.Update(It.IsAny<Sale>())).Returns(updatedSale);

            Assert.Throws<Exception>(() => saleService.Update(1, saleStatus))
                .Message.Should().Be(string.Format(ErrorMessage.errorCancelada, saleStatus));
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
