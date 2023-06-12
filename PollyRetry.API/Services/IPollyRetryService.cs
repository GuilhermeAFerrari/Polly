namespace PollyRetry.API.Services
{
    public interface IPollyRetryService
    {
        Task<bool> TestGetAsync();
    }
}
