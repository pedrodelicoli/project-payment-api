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

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Item(int id, string name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }
    }
}
