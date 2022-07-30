namespace SmitenightApp.Domain.Exceptions
{
    public class NavigationPropertyNullException : InvalidOperationException
    {
        public NavigationPropertyNullException(string navigationName) : base("Uninitialized property: " + navigationName)
        {

        }
    }
}
