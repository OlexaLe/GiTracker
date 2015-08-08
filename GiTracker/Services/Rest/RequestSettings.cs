namespace GiTracker.Services.Rest
{
    public class RequestSettings
    {
        public RequestSettings(string hostName, string url)
        {
            HostName = hostName;
            Url = url;
        }

        public string HostName { get; private set; }
        public string Url { get; private set; }
        public string UserAgent { get; set; }
    }
}
