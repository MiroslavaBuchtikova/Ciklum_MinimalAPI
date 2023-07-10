namespace CustomerService.Core.Exceptions
{
    public class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException(string message = "Customer with given id doesn't exist") : base(message)
        {
        }
    }
}