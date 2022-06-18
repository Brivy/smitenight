namespace Smitenight.Domain.Exceptions
{
    public class NavigationPropertyNullException : InvalidOperationException
    {
        public NavigationPropertyNullException(string navigationName) : base("Uninitialized property: " + navigationName)
        {

        }
    }
}
