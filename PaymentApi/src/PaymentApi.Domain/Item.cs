using PaymentApi.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace PaymentApi.Domain
{
    public class Item
    {
        [Key]
        public int Id { get; set; }        
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Item(string name, int quantity)
        {
            if (string.IsNullOrEmpty(name)) throw new DomainException("O campo Nome é obrigatório!");
            if (quantity <= 0) throw new DomainException("O campo Quantidade deve ser maior que zero!");

            Name = name;
            Quantity = quantity;
        }

        public Item()
        {

        }
    }
}
