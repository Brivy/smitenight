namespace Smitenight.Domain.Models.Exceptions
{
    public class SessionCouldNotBeCreatedException : Exception
    {
        public SessionCouldNotBeCreatedException() : base("The session with the SMITE API could not be created")
        {

        }
    }
}
