namespace Domain.Exceptions
{
    internal class InvalidNameException : Exception
    {
        public InvalidNameException(string message) : base(message) { }
    }
}
