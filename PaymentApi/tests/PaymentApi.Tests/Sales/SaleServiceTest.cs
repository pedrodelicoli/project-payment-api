using AutoMapper;
using PaymentApi.Application;
using PaymentApi.Application.Dto;
using PaymentApi.Domain.Exceptions;
using PaymentApi.Repository.Interfaces;

namespace PaymentApi.Tests.Sales
{
    public class SaleServiceTest
    {
        private readonly SaleService saleService;
        private readonly Mock<ISaleRepository> saleRepositoryMock;
        private readonly Mock<IMapper> autoMapperMock;

        private Seller seller;
        private List<Item> itens;
        private Sale sale;
        private SellerDto sellerDto;
        private List<ItemDto> itensDto;
        private SaleDto saleDto;
        private CreateSellerDto createSellerDto;
        private List<CreateItemDto> createItensDto;
        private CreateSaleDto createSaleDto;
        public SaleServiceTest()
        {
            saleRepositoryMock = new Mock<ISaleRepository>();
            autoMapperMock = new Mock<IMapper>();
            saleService = new(saleRepositoryMock.Object, autoMapperMock.Object);

            seller = new("376628533809", "Pedro", "pedro@delicoli.com", "18998244525");
            itens = new()
            {
                new Item("Carteira", 2)
            };
            sale = new(DateTime.Now, SaleStatus.AguardandoPagamento, seller, itens);

            sellerDto = new("376628533809", "Pedro", "pedro@delicoli.com", "18998244525");

            itensDto = new()
            {
                new ItemDto("Carteira", 2)
            };

            saleDto = new(DateTime.Now, SaleStatus.AguardandoPagamento, sellerDto, itensDto);

            createSellerDto = new("376628533809", "Pedro", "pedro@delicoli.com", "18998244525");

            createItensDto = new()
            {
                new CreateItemDto("Carteira", 2)
            };

            createSaleDto = new(DateTime.Now, createSellerDto, createItensDto);
        }

        [Fact]
        public void ShouldAddSale()
        {
            autoMapperMock.Setup(x => x.Map<Sale>(createSaleDto)).Returns(sale);
            saleRepositoryMock.Setup((s) => s.Create(sale)).Returns(sale);
            autoMapperMock.Setup(x => x.Map<SaleDto>(sale)).Returns(saleDto);

            SaleDto result = saleService.Create(createSaleDto);

            result.Should().BeEquivalentTo(saleDto);
            saleRepositoryMock.Verify((s) => s.Create(It.IsAny<Sale>()), Times.Once);
        }

        [Fact]
        public void ShouldGetSaleById()
        {
            saleRepositoryMock.Setup((s) => s.GetById(It.IsAny<int>())).Returns(sale);
            autoMapperMock.Setup(x => x.Map<SaleDto>(sale)).Returns(saleDto);

            SaleDto result = saleService.GetById(sale.Id);

            result.Should().BeEquivalentTo(saleDto);
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
            SaleDto expectedSaleDto = new(DateTime.Now, saleStatus, sellerDto, itensDto);
            autoMapperMock.Setup(x => x.Map<SaleDto>(updatedSale)).Returns(expectedSaleDto);
            UpdateSaleDto updateSale = new()
            {
                Status = saleStatus
            };

            SaleDto result = saleService.Update(1, updateSale);

            result.Should().BeEquivalentTo(expectedSaleDto);
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
            UpdateSaleDto updateSale = new()
            {
                Status = saleStatus
            };

            Assert.Throws<Exception>(() => saleService.Update(1, updateSale))
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
            SaleDto expectedSaleDto = new(DateTime.Now, saleStatus, sellerDto, itensDto);
            autoMapperMock.Setup(x => x.Map<SaleDto>(updatedSale)).Returns(expectedSaleDto);
            UpdateSaleDto updateSale = new()
            {
                Status = saleStatus
            };

            SaleDto result = saleService.Update(1, updateSale);

            result.Should().BeEquivalentTo(expectedSaleDto);
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
            UpdateSaleDto updateSale = new()
            {
                Status = saleStatus
            };

            Assert.Throws<Exception>(() => saleService.Update(1, updateSale))
                .Message.Should().Be(string.Format(ErrorMessage.errorPagamentoAprovado, saleStatus));
        }

        [Fact]        
        public void ShouldUpdateSaleStatus_WhenCurrentStatusEnviadoTransportador()
        {
            Sale saleTest = new(DateTime.Now, SaleStatus.EnviadoTransportadora, seller, itens);
            saleRepositoryMock.Setup((s) => s.GetById(It.IsAny<int>())).Returns(saleTest);
            Sale updatedSale = new(DateTime.Now, SaleStatus.Entregue, seller, itens);
            saleRepositoryMock.Setup((s) => s.Update(It.IsAny<Sale>())).Returns(updatedSale);
            SaleDto expectedSaleDto = new(DateTime.Now, SaleStatus.Entregue, sellerDto, itensDto);
            autoMapperMock.Setup(x => x.Map<SaleDto>(updatedSale)).Returns(expectedSaleDto);
            UpdateSaleDto updateSale = new()
            {
                Status = SaleStatus.Entregue
            };

            SaleDto result = saleService.Update(1, updateSale);

            result.Should().BeEquivalentTo(expectedSaleDto);
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
            UpdateSaleDto updateSale = new()
            {
                Status = saleStatus
            };

            Assert.Throws<Exception>(() => saleService.Update(1, updateSale))
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
            UpdateSaleDto updateSale = new()
            {
                Status = saleStatus
            };

            Assert.Throws<Exception>(() => saleService.Update(1, updateSale))
                .Message.Should().Be(string.Format(ErrorMessage.errorCancelada, saleStatus));
        }

        [Theory]
        [InlineData(SaleStatus.AguardandoPagamento)]
        [InlineData(SaleStatus.PagamentoAprovado)]
        [InlineData(SaleStatus.EnviadoTransportadora)]
        [InlineData(SaleStatus.Cancelada)]
        public void ShouldThrowsException_WhenTryUpdateCurrentStatusEntregue(SaleStatus saleStatus)
        {
            Sale saleTest = new(DateTime.Now, SaleStatus.Entregue, seller, itens);
            saleRepositoryMock.Setup((s) => s.GetById(It.IsAny<int>())).Returns(saleTest);
            Sale updatedSale = new(DateTime.Now, saleStatus, seller, itens);
            saleRepositoryMock.Setup((s) => s.Update(It.IsAny<Sale>())).Returns(updatedSale);
            UpdateSaleDto updateSale = new()
            {
                Status = saleStatus
            };

            Assert.Throws<Exception>(() => saleService.Update(1, updateSale))
                .Message.Should().Be(string.Format(ErrorMessage.errorEntregue, saleStatus));
        }
    }
}
