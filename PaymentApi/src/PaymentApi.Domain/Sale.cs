namespace PaymentApi.Domain
{
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

        public Sale()
        {

        }
    }
}
