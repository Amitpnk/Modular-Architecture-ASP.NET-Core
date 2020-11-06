using System;
using System.Runtime.Serialization;

namespace HA.Application.Exceptions
{
    [Serializable]
    public class DeleteFailureException : Exception
    {
        public DeleteFailureException(string name, object key, string message)
            : base($"Deletion of entity \"{name}\" ({key}) failed. {message}")
        {
        }

        protected DeleteFailureException(SerializationInfo info, StreamingContext context)
         : base(info, context)
        {
        }
    }
}
