using PaymentApi.Domain.Exceptions;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PaymentApi.Domain
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        public DateTime SaleTime { get; set; }
        public SaleStatus Status { get; set; }
        public Seller Seller { get; set; }
        public List<Item> Itens { get; set; }

        public Sale(DateTime saleTime, SaleStatus status, Seller seller, List<Item> itens)
        {
            if (saleTime == new DateTime()) throw new DomainException("O campo Data é obrigatório!");
            if (seller is null) throw new DomainException("Deve possuir um Vendedor!");
            if (itens is null || !itens.Any() ) throw new DomainException("Um item deve ser adicionado!");

            SaleTime = saleTime;
            Status = status;
            Seller = seller;
            Itens = itens;
        }

        public Sale()
        {

        }
    }
}
