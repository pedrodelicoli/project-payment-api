using PaymentApi.Domain.Exceptions;

namespace PaymentApi.Tests.Sales
{
    public class SaleTest
    {
        private readonly Sale expectedSale;
        private readonly Seller expectedSeller;
        private readonly List<Item> expectedItens;
        private readonly DateTime saleTime = DateTime.Now;
        public SaleTest()
        {
            expectedSeller = new("376628533809", "Pedro", "pedro@delicoli.com", "18998244525");
            expectedItens =  new()
            {
                new Item("Carteira", 2)
            };
            expectedSale = new(saleTime, SaleStatus.AguardandoPagamento, expectedSeller, expectedItens);
        }


        [Fact]
        public void ShouldCreateSale()
        {
            Seller seller = new("376628533809", "Pedro", "pedro@delicoli.com", "18998244525");
            List<Item> itens = new()
            {
                new Item("Carteira", 2)
            };
            var sale = new Sale(saleTime, SaleStatus.AguardandoPagamento, seller, itens);

            sale.Should().BeEquivalentTo(expectedSale);
        }

        [Fact]
        public void ShouldThrowExceptions_WhenSaleTimeIsInvalid()
        {
            Seller seller = new("376628533809", "Pedro", "pedro@delicoli.com", "18998244525");
            List<Item> itens = new()
            {
                new Item("Carteira", 2)
            };
            Assert.Throws<ArgumentException>(() => new Sale(new DateTime(), seller, itens))
                .Message.Should().Be(ErrorMessage.errorSaleTimeIsRequired);
        }

        [Fact]
        public void ShouldThrowExceptions_WhenSellerIsInvalid()
        {
            List<Item> itens = new()
            {
                new Item("Carteira", 2)
            };
            Assert.Throws<ArgumentException>(() => new Sale(saleTime, null, itens))
                .Message.Should().Be(ErrorMessage.errorSaleSellerIsRequired);
        }

        [Fact]
        public void ShouldThrowExceptions_WhenItensIsNull()
        {
            Seller seller = new("376628533809", "Pedro", "pedro@delicoli.com", "18998244525");

            Assert.Throws<ArgumentException>(() => new Sale(saleTime, seller, null))
                .Message.Should().Be(ErrorMessage.errorSaleItemIsRequired);
        }

        [Fact]
        public void ShouldThrowExceptions_WhenItensIsEmpty()
        {
            Seller seller = new("376628533809", "Pedro", "pedro@delicoli.com", "18998244525");

            Assert.Throws<ArgumentException>(() => new Sale(saleTime, seller, new List<Item>()))
                .Message.Should().Be("Um item deve ser adicionado!");
        }
    }   
}
