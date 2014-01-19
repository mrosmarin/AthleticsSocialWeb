using System;
using AthleticsSocialWeb.Common.Logging;
using NLog;
using NLog.Config;

namespace AthleticsSocialWeb.Common.Nlog
{
    public class NLogLoggerFactory : ILoggerFactory
    {

        public NLogLoggerFactory()
        {
            // Register custom NLog Layout renderers
            ConfigurationItemFactory.Default.LayoutRenderers.RegisterDefinition("utc_date", typeof(UtcDateRenderer));
            ConfigurationItemFactory.Default.LayoutRenderers.RegisterDefinition("web_variables", typeof(WebVariablesRenderer));
        }

        public ILogger Create(Type loggerType)
        {

            return new NLogLogger(loggerType);

        }
    }
}
