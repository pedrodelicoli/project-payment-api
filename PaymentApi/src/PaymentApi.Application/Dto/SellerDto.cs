namespace PaymentApi.Application.Dto
{
    public class SellerDto
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public SellerDto( string cpf, string name, string email, string phoneNumber)
        {
            Cpf = cpf;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public SellerDto()
        {

        }
    }
}
