namespace PaymentApi.Domain.Exceptions
{
    public static class ErrorMessage
    {
        public static string errorPagamentoAprovado = "Não é permitido atualizar de Pagamento Aprovado para {0}";
        public static string errorEnviadoTransportadora = "Não é permitido atualizar de Enviado para Transportadora para {0}";
        public static string errorAguardandoPagamento = "Não é permitido atualizar de Aguardando Pagamento para {0}";
        public static string errorCancelada = "Não é permitido atualizar de Cancelada para {0}";
    }
}
