namespace SmitenightApp.Domain.Secrets
{
    public record class SmiteDeveloperSecrets
    {
        public int DeveloperId { get; }
        public string AuthenticationKey { get; }

        public SmiteDeveloperSecrets(int developerId, string authenticationKey)
        {
            DeveloperId = developerId;
            AuthenticationKey = authenticationKey;
        }
    }
}
