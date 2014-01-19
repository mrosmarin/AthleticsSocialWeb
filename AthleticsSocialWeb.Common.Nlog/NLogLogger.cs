using System;
using AthleticsSocialWeb.Common.Logging;
using NLog;
using NLog.Config;

namespace AthleticsSocialWeb.Common.Nlog
{
    public class NLogLogger : ILogger
    {

        private readonly Logger _logger;
     //   private readonly Type _type;

        public NLogLogger(Type loggerType):this()
        {
           // _type = loggerType;
            _logger = LogManager.GetLogger(loggerType.FullName);
        }

        public NLogLogger()
        {
            // Register custom NLog Layout renderers
            ConfigurationItemFactory.Default.LayoutRenderers.RegisterDefinition("utc_date", typeof(UtcDateRenderer));
            ConfigurationItemFactory.Default.LayoutRenderers.RegisterDefinition("web_variables", typeof(WebVariablesRenderer));
            
        }
/*
        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Warn(string message)
        {
            _logger.Warn(message);
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Error(Exception x)
        {
            Error(LogUtility.BuildExceptionMessage(x));
        }

        public void Error(string message, Exception x)
        {
            _logger.ErrorException(message, x);
        }

        public void Fatal(string message)
        {
            _logger.Fatal(message);
        }

        public void Fatal(Exception x)
        {
            Fatal(LogUtility.BuildExceptionMessage(x));
        }

        public void Debug(string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Debug(string message, Exception exception, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Debug(object item)
        {
            throw new NotImplementedException();
        }

        public void Fatal(string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Fatal(string message, Exception exception, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void LogInfo(string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void LogWarning(string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void LogError(string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void LogError(string message, Exception exception, params object[] args)
        {
            throw new NotImplementedException();
        }
 */

        public void Debug(string message, params object[] args)
        {
            _logger.Debug(message,args);
        }

        public void Debug(string message, Exception exception, params object[] args)
        {
            _logger.DebugException(string.Format(message, args), exception);
        }

        public void Debug(object item)
        {
            _logger.Debug(item);
        }

        public void Fatal(string message, params object[] args)
        {
            _logger.Fatal(message,args);
        }

        public void Fatal(string message, Exception exception, params object[] args)
        {
            _logger.FatalException(string.Format(message, args), exception);
        }

        public void Info(string message, params object[] args)
        {
            _logger.Info(message,args);
        }

        public void Warning(string message, params object[] args)
        {
            _logger.Warn(message,args);
        }

        public void Error(string message, params object[] args)
        {
            _logger.Error(message,args);
        }

        public void Error(string message, Exception exception, params object[] args)
        {
            _logger.ErrorException(string.Format(message,args),exception);
        }

        public void SetloggerType(LoggerTypeEnum loggerType)
        {
            throw new NotImplementedException();
        }
    }
}