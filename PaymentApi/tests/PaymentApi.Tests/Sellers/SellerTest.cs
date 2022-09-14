namespace PaymentApi.Tests.Vendedores
{
    public class SellerTest
    {
        private readonly Seller expectedSeller;
        public SellerTest()
        {
            expectedSeller = new(1, "376628533809", "Pedro", "pedro@delicoli.com", "18998244525");
        }


        [Fact]
        public void ShouldCreateSeller()
        {
            Seller seller = new(1, "376628533809", "Pedro", "pedro@delicoli.com", "18998244525");

            seller.Should().BeEquivalentTo(expectedSeller);
        }
    }    
}
