using Microsoft.Extensions.Logging;

namespace Sample_WebApiDependencyInjection.Logger
{
    public static class EventHubLoggerProviderExtensions
    {
        public static ILoggerFactory AddEventHubLogger(this ILoggerFactory loggerFactory, string eventHubName, string serviceBusNamespace, string sasToken, string subSystem)
        {
            loggerFactory.AddProvider(new EventHubLoggerProvider(eventHubName, serviceBusNamespace, sasToken, subSystem));

            return loggerFactory;
        }
    }
}
