namespace PaymentApi.Tests.Itens
{
    public class ItemTest
    {
        private readonly Item expectedItem;
        public ItemTest()
        {
            expectedItem = new(1, "Carteira", 2);
        }


        [Fact]
        public void ShouldCreateItem()
        {
            Item item = new(1, "Carteira", 2);

            item.Should().BeEquivalentTo(expectedItem);
        }
    }
    
}
