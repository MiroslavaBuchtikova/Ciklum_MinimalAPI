namespace CustomerService.Core.Exceptions
{
    public class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException(string message = "CustomerEntity not found") : base(message)
        {
        }
    }
}