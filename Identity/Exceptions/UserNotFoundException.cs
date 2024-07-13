namespace Identity.Api.Exceptions
{
    public class UserNotFoundException(string? message) : Exception(message)
    {
        private static string DefaultMessage = "User not found";

        public UserNotFoundException() : this(DefaultMessage)
        {
        }
    }
}
