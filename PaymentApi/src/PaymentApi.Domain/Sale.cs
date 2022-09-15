using PaymentApi.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace PaymentApi.Domain
{
    public class Sale
    {
        [Key]
        public int Id { get; private set; }
        public DateTime SaleTime { get; private set; }
        public SaleStatus Status { get; private set; }
        public Seller Seller { get; private set; }
        public List<Item> Itens { get; private set; }

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

        public void UpdateStatus(SaleStatus saleStatus)
        {
            CheckIfStatusChangeIsValid(saleStatus);
            Status = saleStatus;           
        }

        private void CheckIfStatusChangeIsValid(SaleStatus saleStatus)
        {
            if (Status == SaleStatus.AguardandoPagamento && (saleStatus == SaleStatus.EnviadoTransportadora || saleStatus == SaleStatus.Entregue))
                throw new Exception(string.Format(ErrorMessage.errorAguardandoPagamento, saleStatus));
            if (Status == SaleStatus.PagamentoAprovado && (saleStatus == SaleStatus.Entregue || saleStatus == SaleStatus.AguardandoPagamento))
                throw new Exception(string.Format(ErrorMessage.errorPagamentoAprovado, saleStatus));
            if (Status == SaleStatus.EnviadoTransportadora && (saleStatus == SaleStatus.AguardandoPagamento || saleStatus == SaleStatus.PagamentoAprovado || saleStatus == SaleStatus.Cancelada))
                throw new Exception(string.Format(ErrorMessage.errorEnviadoTransportadora, saleStatus));
            if (Status == SaleStatus.Cancelada && saleStatus != SaleStatus.Cancelada)
                throw new Exception(string.Format(ErrorMessage.errorCancelada, saleStatus));
        }
    }
}
