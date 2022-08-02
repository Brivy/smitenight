namespace SmitenightApp.Domain.Exceptions
{
    public class SessionCouldNotBeCreatedException : Exception
    {
        public SessionCouldNotBeCreatedException() : base("The session with the SMITE API could not be created")
        {

        }
    }
}
