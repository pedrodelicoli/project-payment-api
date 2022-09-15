using PaymentApi.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace PaymentApi.Domain
{
    public class Item
    {
        [Key]
        public int Id { get; private set; }        
        public string Name { get; private set; }
        public int Quantity { get; private set; }

        public Item(string name, int quantity)
        {
            if (string.IsNullOrEmpty(name)) throw new DomainException(ErrorMessage.errorItemNameIsRequired);
            if (quantity <= 0) throw new DomainException(ErrorMessage.errorItemQuantityIsRequired);

            Name = name;
            Quantity = quantity;
        }

        public Item()
        {

        }
    }
}
