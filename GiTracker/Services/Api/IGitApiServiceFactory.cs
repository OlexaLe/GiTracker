namespace GiTracker.Services.Api
{
    public interface IGitApiServiceFactory
    {
        IGitApiService GetApiService();
        IGitApiService GetApiService(GitApiServiceType apiServiceType);
    }
}
