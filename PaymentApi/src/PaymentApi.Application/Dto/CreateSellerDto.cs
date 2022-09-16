namespace PaymentApi.Application.Dto
{
    public class CreateSellerDto
    {
        /// <summary>
        /// CPF do vendedor
        /// </summary>
        public string? Cpf { get; set; }
        /// <summary>
        /// Nome do vendedor
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Email do vendedor
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Telefone do vendedor
        /// </summary>
        public string? PhoneNumber { get; set; }

        public CreateSellerDto(string cpf, string name, string email, string phoneNumber)
        {
            Cpf = cpf;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public CreateSellerDto()
        {

        }
    }
}
