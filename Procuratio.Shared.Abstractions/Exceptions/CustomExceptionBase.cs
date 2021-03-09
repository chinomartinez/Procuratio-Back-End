using System;

namespace Procuratio.Shared.Abstractions.Exceptions
{
    public class CustomExceptionBase : Exception
    {
        protected CustomExceptionBase(string message) : base(message)
        {
        }
    }
}
