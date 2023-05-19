using System.Runtime.Serialization;

namespace Smitenight.Providers.SmiteProvider.Contracts.Exceptions
{
    [Serializable]
    public class SmiteClientRequestException : Exception
    {
        public SmiteClientRequestException()
        {
        }

        public SmiteClientRequestException(string message) : base(message)
        {
        }

        public SmiteClientRequestException(string message, Exception inner) : base(message, inner)
        {
        }

        protected SmiteClientRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
