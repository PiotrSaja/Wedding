namespace Identity.Api.Models.Token
{
    public class TokenModel
    {
        public Dictionary<string, string> Tokens { get; set; }
        public DateTime ExpirationDateUtc { get; set; }
    }

    public enum TokenType
    {
        ACCESS,
        REFRESH
    }
}
