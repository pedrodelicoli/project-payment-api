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
            var seller = new Seller(1, "376628533809", "Pedro", "pedro@delicoli.com", "18998244525");

            seller.Should().NotBeNull();
            seller.Should().BeEquivalentTo(expectedSeller);
        }
    }

    public class Seller
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Seller(int id, string cpf, string name, string email, string phoneNumber)
        {
            Id = id;
            Cpf = cpf;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
