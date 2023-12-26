namespace Smitenight.Providers.SmiteProvider.HiRez.Exceptions;

[Serializable]
internal class SmiteClientInvalidResponseException : Exception
{
    public SmiteClientInvalidResponseException()
    {
    }

    public SmiteClientInvalidResponseException(string message) : base(message)
    {
    }

    public SmiteClientInvalidResponseException(string message, Exception inner) : base(message, inner)
    {
    }
}
