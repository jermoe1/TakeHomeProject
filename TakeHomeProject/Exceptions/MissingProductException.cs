namespace TakeHomeProject.Exceptions
{
    public class MissingProductException : Exception
    {
        public MissingProductException(string message) : base(message) { }
    }
}
