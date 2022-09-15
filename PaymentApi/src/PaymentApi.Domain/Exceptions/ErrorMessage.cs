namespace PaymentApi.Domain.Exceptions
{
    public static class ErrorMessage
    {
        public static string errorPagamentoAprovado = "Não é permitido atualizar de Pagamento Aprovado para {0}";
        public static string errorEnviadoTransportadora = "Não é permitido atualizar de Enviado para Transportadora para {0}";
        public static string errorAguardandoPagamento = "Não é permitido atualizar de Aguardando Pagamento para {0}";
        public static string errorCancelada = "Não é permitido atualizar de Cancelada para {0}";

        // Error Seller

        public static string errorSellerCpfIsRequired = "O campo CPF é obrigatório!";
        public static string errorSellerNameIsRequired = "O campo Nome é obrigatório!";
        public static string errorSellerEmailIsRequired = "O campo Email é obrigatório!";
        public static string errorSellerPhoneNumberIsRequired = "O campo Telefone é obrigatório!";


        // Error Item 

        public static string errorItemNameIsRequired = "O campo Nome é obrigatório!";
        public static string errorItemQuantityIsRequired = "O campo Quantidade deve ser maior que zero!";

        // Error Sale

        public static string errorSaleTimeIsRequired = "O campo Data é obrigatório!";
        public static string errorSaleSellerIsRequired = "Deve possuir um Vendedor!";
        public static string errorSaleItemIsRequired = "Um item deve ser adicionado!";
    }
}
