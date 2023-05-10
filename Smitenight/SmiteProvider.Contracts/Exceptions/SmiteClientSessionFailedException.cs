﻿using System.Runtime.Serialization;

namespace Smitenight.Providers.SmiteProvider.Contracts.Exceptions
{
    [Serializable]
    public class SmiteClientSessionFailedException : Exception
    {
        public SmiteClientSessionFailedException()
        {
        }

        public SmiteClientSessionFailedException(string message) : base(message)
        {
        }

        public SmiteClientSessionFailedException(string message, Exception inner) : base(message, inner)
        {
        }

        protected SmiteClientSessionFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
