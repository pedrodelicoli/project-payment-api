namespace PaymentApi.Domain.Exceptions
{
    public class DomainException : ArgumentException
    {
        public DomainException(string input)
        {
            throw new ArgumentException(input);
        }
    }
}
