namespace BlabberApp.DataStore.Exceptions
{

    public class BlabAdapterException : SystemException
    {
        public BlabAdapterException(string message) : base(message) { }
        public BlabAdapterException(string message, Exception inner) : base(message, inner) { }
    }

    public class BlabAdapterNotFoundException : Exception
    {
        public BlabAdapterNotFoundException(string message) : base(message) { }
        public BlabAdapterNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}