using System;

namespace BigFootVentures.Business.Objects.Exceptions
{
    public sealed class ApplicationException : Exception
    {
        public ApplicationException(string errorMessage) : base(errorMessage)
        {

        }
    }
}
