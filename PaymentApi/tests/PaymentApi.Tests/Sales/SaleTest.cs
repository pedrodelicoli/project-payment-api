﻿namespace PaymentApi.Tests.Sales
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
            Assert.Throws<ArgumentException>(() => new Sale(new DateTime(), SaleStatus.AguardandoPagamento, seller, itens))
                .Message.Should().Be("O campo Data é obrigatório!");
        }

        [Fact]
        public void ShouldThrowExceptions_WhenSellerIsInvalid()
        {
            List<Item> itens = new()
            {
                new Item("Carteira", 2)
            };
            Assert.Throws<ArgumentException>(() => new Sale(saleTime, SaleStatus.AguardandoPagamento, null, itens))
                .Message.Should().Be("Deve possuir um Vendedor!");
        }

        [Fact]
        public void ShouldThrowExceptions_WhenItensIsNull()
        {
            Seller seller = new("376628533809", "Pedro", "pedro@delicoli.com", "18998244525");

            Assert.Throws<ArgumentException>(() => new Sale(saleTime, SaleStatus.AguardandoPagamento, seller, null))
                .Message.Should().Be("Um item deve ser adicionado!");
        }

        [Fact]
        public void ShouldThrowExceptions_WhenItensIsEmpty()
        {
            Seller seller = new("376628533809", "Pedro", "pedro@delicoli.com", "18998244525");

            Assert.Throws<ArgumentException>(() => new Sale(saleTime, SaleStatus.AguardandoPagamento, seller, new List<Item>()))
                .Message.Should().Be("Um item deve ser adicionado!");
        }
    }   
}
