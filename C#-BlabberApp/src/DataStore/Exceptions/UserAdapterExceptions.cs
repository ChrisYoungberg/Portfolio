namespace BlabberApp.DataStore.Exceptions
{

    public class UserAdapterException : SystemException
    {
        public UserAdapterException(string message) : base(message) { }
    }
    public class UserAdapterNotFoundException : Exception
    {
        public UserAdapterNotFoundException(string message) : base(message) { }
    }
    public class UserAdapterDuplicateException : Exception
    {
        public UserAdapterDuplicateException(string message) : base(message) { }
    }
}