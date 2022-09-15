using PaymentApi.Domain.Exceptions;

namespace PaymentApi.Application.Dto
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public ItemDto(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public ItemDto()
        {

        }

    }
}
