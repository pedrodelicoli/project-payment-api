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
            if (string.IsNullOrEmpty(cpf)) throw new DomainException("O campo CPF é obrigatório!");
            if (string.IsNullOrEmpty(name)) throw new DomainException("O campo Nome é obrigatório!");
            if (string.IsNullOrEmpty(email)) throw new DomainException("O campo Email é obrigatório!");
            if (string.IsNullOrEmpty(phoneNumber)) throw new DomainException("O campo Telefone é obrigatório!");

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
