namespace PaymentApi.Tests.Itens
{
    public class ItemTest
    {
        private readonly Item expectedItem;
        public ItemTest()
        {
            expectedItem = new("Carteira", 2);
        }


        [Fact]
        public void ShouldCreateItem()
        {
            Item item = new("Carteira", 2);

            item.Should().BeEquivalentTo(expectedItem);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldThrowExceptions_WhenNameIsInvalid(string invalidName)
        {
            Assert.Throws<ArgumentException>(() => new Item(invalidName, 2))
                .Message.Should().Be("O campo Nome é obrigatório!");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-7)]
        public void ShouldThrowExceptions_WhenQuantityIsInvalid(int invalidQuantity)
        {
            Assert.Throws<ArgumentException>(() => new Item("Carteira", invalidQuantity))
                .Message.Should().Be("O campo Quantidade deve ser maior que zero!");
        }
    }
    
}
