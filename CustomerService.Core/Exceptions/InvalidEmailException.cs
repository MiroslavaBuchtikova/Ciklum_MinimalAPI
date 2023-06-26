namespace MinimalAPI.Core.Exceptions
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException(string message = "Email address is invalid") : base(message)
        {
        }
    }
}