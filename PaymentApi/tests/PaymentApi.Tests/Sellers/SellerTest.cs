using PaymentApi.Domain;
using PaymentApi.Domain.Exceptions;

namespace PaymentApi.Tests.Vendedores
{
    public class SellerTest
    {
        private readonly Seller expectedSeller;
        public SellerTest()
        {
            expectedSeller = new("376628533809", "Pedro", "pedro@delicoli.com", "18998244525");
        }


        [Fact]
        public void ShouldCreateSeller()
        {
            Seller seller = new("376628533809", "Pedro", "pedro@delicoli.com", "18998244525");

            seller.Should().BeEquivalentTo(expectedSeller);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldThrowExceptions_WhenCPFIsInvalid(string invalidCpf)
        {
            Assert.Throws<ArgumentException>(() => new Seller(invalidCpf, "Pedro", "pedro@delicoli.com", "18998244525"))
                .Message.Should().Be(ErrorMessage.errorSellerCpfIsRequired);               
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldThrowExceptions_WhenNameIsInvalid(string invalidName)
        {
            Assert.Throws<ArgumentException>(() => new Seller("376628533809", invalidName, "pedro@delicoli.com", "18998244525"))
                .Message.Should().Be(ErrorMessage.errorSellerNameIsRequired);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldThrowExceptions_WhenEmailIsInvalid(string invalidEmail)
        {
            Assert.Throws<ArgumentException>(() => new Seller("376628533809", "Pedro", invalidEmail, "18998244525"))
                .Message.Should().Be(ErrorMessage.errorSellerEmailIsRequired);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldThrowExceptions_WhenPhoneNumberIsInvalid(string invalidPhoneNumber)
        {
            Assert.Throws<ArgumentException>(() => new Seller("376628533809", "Pedro", "pedro@delicoli.com", invalidPhoneNumber))
                .Message.Should().Be(ErrorMessage.errorSellerPhoneNumberIsRequired);
        }
    }
}
