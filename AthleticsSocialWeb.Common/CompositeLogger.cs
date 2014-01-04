using System;
using System.Collections.Generic;
using System.Linq;

namespace AthleticsSocialWeb.Common
{
    public sealed class CompositeLogger : ILogger
    {
        private LoggerTypeEnum Logger { get; set; }
 
        private IDictionary<LoggerTypeEnum, ILogger> Loggers { get; set; }

        public CompositeLogger(LoggerTypeEnum defaultLogger, IEnumerable<Tuple<LoggerTypeEnum, ILogger>> loggers)
        {
            Loggers = loggers.ToDictionary(k => k.Item1, v => v.Item2);
            Logger = defaultLogger;
        }

        public void SetloggerType(LoggerTypeEnum loggerType)
        {
            Logger = loggerType;
        }

        public void Debug(string message, params object[] args)
        {
            if (Logger == LoggerTypeEnum.All)
            {
                Loggers.Select(v => v.Value).ToList().ForEach(l => l.Debug(message, args));
                return;
            }
            Loggers[Logger].Debug(message,args);
        }

        public void Debug(string message, Exception exception, params object[] args)
        {
            if (Logger == LoggerTypeEnum.All)
            {
                Loggers.Select(v => v.Value).ToList().ForEach(l => l.Debug(message, exception, args));
                return;
            }
            Loggers[Logger].Debug(message, exception, args);
        }

        public void Debug(object item)
        {
            if (Logger == LoggerTypeEnum.All)
            {
                Loggers.Select(v => v.Value).ToList().ForEach(l => l.Debug(item));
                return;
            }
            Loggers[Logger].Debug(item);
        }

        public void Fatal(string message, params object[] args)
        {
            if (Logger == LoggerTypeEnum.All)
            {
                Loggers.Select(v => v.Value).ToList().ForEach(l => l.Fatal(message, args));
                return;
            }
            Loggers[Logger].Fatal(message,args);
        }

        public void Fatal(string message, Exception exception, params object[] args)
        {
            if (Logger == LoggerTypeEnum.All)
            {
                Loggers.Select(v => v.Value).ToList().ForEach(l => l.Fatal(message, exception, args));
                return;
            }
            Loggers[Logger].Fatal(message,exception,args);
        }

        public void Info(string message, params object[] args)
        {
            if (Logger == LoggerTypeEnum.All)
            {
                Loggers.Select(v => v.Value).ToList().ForEach(l => l.Info(message, args));
                return;
            }
            Loggers[Logger].Info(message,args);
        }

        public void Warning(string message, params object[] args)
        {
            if (Logger == LoggerTypeEnum.All)
            {
                Loggers.Select(v => v.Value).ToList().ForEach(l => l.Warning(message, args));
                return;
            }
            Loggers[Logger].Warning(message,args);
        }

        public void Error(string message, params object[] args)
        {
            if (Logger == LoggerTypeEnum.All)
            {
                Loggers.Select(v => v.Value).ToList().ForEach(l => l.Error(message, args));
                return;
            }
            Loggers[Logger].Error(message,args);
        }

        public void Error(string message, Exception exception, params object[] args)
        {
            if (Logger == LoggerTypeEnum.All)
            {
                Loggers.Select(v => v.Value).ToList().ForEach(l => l.Error(message, exception, args));
                return;
            }
            Loggers[Logger].Error(message,exception,args);
        }

    }
}
