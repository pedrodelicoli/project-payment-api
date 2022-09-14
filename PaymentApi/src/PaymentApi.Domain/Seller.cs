﻿namespace PaymentApi.Domain
{
    public class Seller
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Seller(int id, string cpf, string name, string email, string phoneNumber)
        {
            Id = id;
            Cpf = cpf;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
