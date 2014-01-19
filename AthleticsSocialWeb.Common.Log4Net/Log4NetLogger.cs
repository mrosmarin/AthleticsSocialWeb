

using System;
using AthleticsSocialWeb.Common.Logging;
using log4net;

namespace AthleticsSocialWeb.Common.Log4Net
{
    public class Log4NetLogger : ILogger
    {
        private ILog Logger { get; set; }

        static Log4NetLogger()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public Log4NetLogger(Type loggerType)
        {
            Logger = LogManager.GetLogger(loggerType);
        }
        public void Debug(string message, params object[] args)
        {
            Logger.DebugFormat(message, args);
        }

        public void Debug(string message, Exception exception, params object[] args)
        {

            Logger.DebugFormat(LogUtility.BuildExceptionMessage(exception, message, args));
        }

        public void Debug(object item)
        {
            Logger.Debug(item);
        }

        public void Fatal(string message, params object[] args)
        {
            Logger.FatalFormat(message, args);
        }

        public void Fatal(string message, System.Exception exception, params object[] args)
        {
            Logger.Fatal(LogUtility.BuildExceptionMessage(exception, message, args));
        }

        public void Info(string message, params object[] args)
        {
            Logger.InfoFormat(message, args);
        }

        public void Warning(string message, params object[] args)
        {
            Logger.WarnFormat(message, args);
        }

        public void Error(string message, params object[] args)
        {
            Logger.ErrorFormat(message, args);
        }

        public void Error(string message, System.Exception exception, params object[] args)
        {
            Logger.Error(LogUtility.BuildExceptionMessage(exception, message, args));
        }

        public void SetloggerType(LoggerTypeEnum loggerType)
        {
            throw new NotImplementedException();
        }
    }
}
