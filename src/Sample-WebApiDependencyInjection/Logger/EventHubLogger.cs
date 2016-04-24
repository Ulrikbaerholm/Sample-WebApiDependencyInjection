using System;
using System.Net.Http;
using System.Text;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Sample_WebApiDependencyInjection.Logger
{
    public class EventHubLogger : ILogger
    {
        private readonly string _categoryName;
        private readonly string _eventHubName;
        private readonly string _serviceBusNamespace;
        private readonly string _sasToken;
        private readonly string _subSystem;

        public EventHubLogger(string categoryName, string eventHubName, string serviceBusNamespace, string sasToken, string subSstem)
        {
            _categoryName = categoryName;
            _eventHubName = eventHubName;
            _serviceBusNamespace = serviceBusNamespace;
            _sasToken = sasToken;
            _subSystem = subSstem;
        }

        public void Log(LogLevel logLevel, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
        {
            var url = string.Format("{0}/publishers/{1}/messages", _eventHubName, _subSystem);

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(string.Format("https://{0}.servicebus.windows.net/", _serviceBusNamespace))
            };

            var payload = JsonConvert.SerializeObject(ConvertToAnonymous(logLevel, eventId, state, exception, formatter));

            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", _sasToken);

            var content = new StringContent(payload, Encoding.UTF8, "application/json");
            httpClient.PostAsync(url, content);
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public IDisposable BeginScopeImpl(object state)
        {
            return new NoopDisposable();
        }

        private class NoopDisposable : IDisposable
        {
            public void Dispose()
            {
            }
        }

        private object ConvertToAnonymous(LogLevel logLevel, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
        {
            string exString = string.Empty;
            if (exception != null)
            {
                exString = formatter(state, exception);
            }
            string timeString = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff");
            return new
            {
                level = logLevel,
                time = timeString,
                ex = exString,
                system = _subSystem
            };
        }
    }
}
