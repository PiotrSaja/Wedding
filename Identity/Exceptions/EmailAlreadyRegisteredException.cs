namespace Identity.Api.Exceptions
{
    public class EmailAlreadyRegisteredException(string? message) : Exception(message)
    {
        private static string DefaultMessage = "Email already exists in system";

        public EmailAlreadyRegisteredException() : this(DefaultMessage)
        {
        }
    }
}
