namespace PaymentApi.Tests.Sales
{
    public class SalesTest
    {
        private readonly Sale expectedSale;
        private readonly Seller expectedSeller;
        private readonly List<Item> expectedItens;
        private readonly DateTime saleTime = DateTime.Now;
        public SalesTest()
        {
            expectedSeller = new(1, "376628533809", "Pedro", "pedro@delicoli.com", "18998244525");
            expectedItens =  new()
            {
                new Item(1, "Wallet", 2)
            };
            expectedSale = new(1, saleTime, SaleStatus.AguardandoPagamento, expectedSeller, expectedItens);
        }


        [Fact]
        public void ShouldCreateSale()
        {
            Seller seller = new(1, "376628533809", "Pedro", "pedro@delicoli.com", "18998244525");
            List<Item> itens = new()
            {
                new Item(1, "Wallet", 2)
            };
            var sale = new Sale(1, saleTime, SaleStatus.AguardandoPagamento, seller, itens);

            sale.Should().BeEquivalentTo(expectedSale);
        }
    }   
}
