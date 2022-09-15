using PaymentApi.Domain.Exceptions;

namespace PaymentApi.Application.Dto
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public ItemDto(int id, string name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }

        public ItemDto()
        {

        }

    }
}
