using System.ComponentModel.DataAnnotations;

namespace PaymentApi.Domain
{
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
