using PaymentApi.Tests.Itens;
using PaymentApi.Tests.Vendedores;
using System.ComponentModel.DataAnnotations;

namespace PaymentApi.Tests.Sales
{
    public class SalesTest
    {
        private readonly Sale expectedSale;
        private readonly Seller expectedSeller;
        private readonly List<Item> expectedItens;
        private readonly DateTime saleTime = DateTime.Now;
        public SalesTest()
        {
            expectedSeller = new(1, "376628533809", "Pedro", "pedro@delicoli.com", "18998244525");
            expectedItens =  new()
            {
                new Item(1, "Wallet", 2)
            };
            expectedSale = new(1, saleTime, SaleStatus.AguardandoPagamento, expectedSeller, expectedItens);
        }


        [Fact]
        public void ShouldCreateSale()
        {
            Seller seller = new(1, "376628533809", "Pedro", "pedro@delicoli.com", "18998244525");
            List<Item> itens = new()
            {
                new Item(1, "Wallet", 2)
            };
            var sale = new Sale(1, saleTime, SaleStatus.AguardandoPagamento, seller, itens);

            sale.Should().BeEquivalentTo(expectedSale);
        }
    }

    public class Sale
    {
        public int Id { get; set; }
        public DateTime SaleTime { get; set; }
        public SaleStatus Status { get; set; }
        public Seller Seller { get; set; }
        public List<Item> Itens { get; set; }

        public Sale(int id, DateTime saleTime, SaleStatus status, Seller seller, List<Item> itens)
        {
            Id = id;
            SaleTime = saleTime;
            Status = status;
            Seller = seller;
            Itens = itens;
        }
    }

    public enum SaleStatus
    {
        [Display(Name = "Aguardando Pagamento")] 
        AguardandoPagamento, 

        [Display(Name = "Pagamento Aprovado")] 
        PagamentoAprovado,
        
        [Display(Name = "Enviado para Transportadora")] 
        EnviadoTransportadora, 

        [Display(Name = "Entregue")] 
        Entregue,
        
        [Display(Name = "Cancelada")] 
        Cancelada,
    }
}
