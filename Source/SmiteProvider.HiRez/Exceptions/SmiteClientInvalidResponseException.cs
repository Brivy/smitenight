﻿using System.Runtime.Serialization;

namespace Smitenight.Providers.SmiteProvider.HiRez.Exceptions
{
    [Serializable]
    public class SmiteClientInvalidResponseException : Exception
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

        protected SmiteClientInvalidResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}