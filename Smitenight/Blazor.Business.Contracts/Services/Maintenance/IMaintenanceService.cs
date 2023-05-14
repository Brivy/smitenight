namespace Smitenight.Application.Blazor.Business.Services.Maintenance
{
    public interface IMaintenanceService
    {
        string CalculateChecksum<T>(T @object);
    }
}