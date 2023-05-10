using System.Runtime.Serialization;

namespace Smitenight.Providers.SmiteProvider.Contracts.Exceptions
{
    [Serializable]
    public class SmiteClientPingFailedException : Exception
    {
        public SmiteClientPingFailedException()
        {
        }

        public SmiteClientPingFailedException(string message) : base(message)
        {
        }

        public SmiteClientPingFailedException(string message, Exception inner) : base(message, inner)
        {
        }

        protected SmiteClientPingFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
