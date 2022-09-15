using PaymentApi.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace PaymentApi.Domain
{
    public class Seller
    {
        [Key]
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Seller(string cpf, string name, string email, string phoneNumber)
        {
            if (string.IsNullOrEmpty(cpf)) throw new DomainException(ErrorMessage.errorSellerCpfIsRequired);
            if (string.IsNullOrEmpty(name)) throw new DomainException(ErrorMessage.errorSellerNameIsRequired);
            if (string.IsNullOrEmpty(email)) throw new DomainException(ErrorMessage.errorSellerEmailIsRequired);
            if (string.IsNullOrEmpty(phoneNumber)) throw new DomainException(ErrorMessage.errorSellerPhoneNumberIsRequired);

            Cpf = cpf;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public Seller()
        {

        }
    }
}
