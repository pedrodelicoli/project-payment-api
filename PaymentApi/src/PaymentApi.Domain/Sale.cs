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
            SaleTime = saleTime;
            Status = status;
            Seller = seller;
            Itens = itens;
        }

        public Sale(DateTime saleTime, Seller seller, List<Item> itens)
        {
            if (saleTime == new DateTime()) throw new DomainException(ErrorMessage.errorSaleTimeIsRequired);
            if (seller is null) throw new DomainException(ErrorMessage.errorSaleSellerIsRequired);
            if (itens is null || !itens.Any()) throw new DomainException(ErrorMessage.errorSaleItemIsRequired);

            SaleTime = saleTime;
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
            if (Status == SaleStatus.Entregue && saleStatus != SaleStatus.Entregue)
                throw new Exception(string.Format(ErrorMessage.errorEntregue, saleStatus));
            if (Status == SaleStatus.Cancelada && saleStatus != SaleStatus.Cancelada)
                throw new Exception(string.Format(ErrorMessage.errorCancelada, saleStatus));
        }
    }
}
