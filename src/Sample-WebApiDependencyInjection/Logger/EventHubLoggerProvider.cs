using Microsoft.Extensions.Logging;


namespace Sample_WebApiDependencyInjection.Logger
{
    public class EventHubLoggerProvider : ILoggerProvider
    {
        private readonly string _eventHubName;
        private readonly string _serviceBusNamespace;
        private readonly string _sasToken;
        private readonly string _subSystem;

        public EventHubLoggerProvider(string eventHubName, string serviceBusNamespace, string sasToken, string subSystem)
        {
            _eventHubName = eventHubName;
            _serviceBusNamespace = serviceBusNamespace;
            _sasToken = sasToken;
            _subSystem = subSystem;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new EventHubLogger(categoryName, _eventHubName, _serviceBusNamespace, _sasToken, _subSystem);
        }

        public void Dispose()
        {
        }
    }
}
