﻿using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using AthleticsSocialWeb.Core.Entities.Logging;

namespace AthleticsSocialWeb.Repository
{
    /// <summary>
    /// This class extracts information that Log4Net stores so that we can report on it
    /// </summary>
    public class Log4NetRepository : AbstractLogEventRepository<Logging>
    {
        /// <summary>
        /// Default Constructor uses the default Entity Container
        /// </summary>
        public Log4NetRepository()
            : base(new Logging())
        {
        }

        /// <summary>
        /// Overloaded constructor that can take an EntityContainer as a parameter so that it can be mocked out by our tests
        /// </summary>
        /// <param name="context">The Entity context</param>
        public Log4NetRepository(DbContext context)
            : base(context)
        {

        }

        /// <summary>
        /// Gets a filtered list of log events
        /// </summary>
        /// <param name="pageIndex">0 based page index</param>
        /// <param name="pageSize">max number of records to return</param>
        /// <param name="start">start date</param>
        /// <param name="end">end date</param>
        /// <param name="logLevel">The level of the log messages</param>
        /// <returns>A filtered list of log events</returns>
        public override IQueryable<LogEvent> GetByDateRangeAndType(int pageIndex, int pageSize, DateTime start, DateTime end, string logLevel)
        {
            IQueryable<LogEvent> list = (from b in DbContext.Log4Net_Error
                                         where b.Date >= start && b.Date <= end
                                         && (b.Level == logLevel || logLevel == "All")
                                         select new LogEvent
                                         {
                                             IdType = "number"
                                             ,
                                             Id = ""
                                             ,
                                             IdAsInteger = b.Id
                                             ,
                                             IdAsGuid = Guid.NewGuid()
                                             ,
                                             LoggerProviderName = "Log4Net"
                                             ,
                                             LogDate = b.Date
                                             ,
                                             MachineName = b.Thread
                                             ,
                                             Message = b.Message
                                             ,
                                             Type = ""
                                             ,
                                             Level = b.Level
                                             ,
                                             Source = b.Thread
                                             ,
                                             StackTrace = ""
                                         });

            return list;
        }

        /// <summary>
        /// Returns a single Log event
        /// </summary>
        /// <param name="id">Id of the log event as a string</param>
        /// <returns>A single Log event</returns>
        public override LogEvent GetById(string id)
        {
            int logEventId = Convert.ToInt32(id);

            LogEvent logEvent = (from b in DbContext.Log4Net_Error
                                 where b.Id == logEventId
                                 select new LogEvent
                                 {
                                     IdType = "number"
                                     ,
                                     IdAsInteger = b.Id
                                     ,
                                     LoggerProviderName = "Log4Net"
                                     ,
                                     LogDate = b.Date
                                     ,
                                     MachineName = b.Thread
                                     ,
                                     Message = b.Message
                                     ,
                                     Type = ""
                                     ,
                                     Level = b.Level
                                     ,
                                     Source = b.Thread
                                     ,
                                     StackTrace = ""
                                     ,
                                     AllXml = ""
                                 })
            .SingleOrDefault();

            return logEvent;
        }

        /// <summary>
        /// Clears log messages between a date range and for specified log levels
        /// </summary>
        /// <param name="start">start date</param>
        /// <param name="end">end date</param>
        /// <param name="logLevels">string array of log levels</param>
        public override void ClearLog(DateTime start, DateTime end, string[] logLevels)
        {
            string logLevelList = logLevels.Aggregate("", (current, logLevel) => current + (",'" + logLevel + "'"));
            if (logLevelList.Length > 0)
            {
                logLevelList = logLevelList.Substring(1);
            }

            const string commandText = "delete from Log4Net_Error WHERE [Date] >= @p0 and [Date] <= @p1 and Level in (@p2)";

            var paramStartDate = new SqlParameter { ParameterName = "p0", Value = start.ToUniversalTime(), DbType = System.Data.DbType.DateTime };
            var paramEndDate = new SqlParameter { ParameterName = "p1", Value = end.ToUniversalTime(), DbType = System.Data.DbType.DateTime };
            var paramLogLevelList = new SqlParameter { ParameterName = "p2", Value = logLevelList };

            DbContext.Database.ExecuteSqlCommand(commandText, paramStartDate, paramEndDate, paramLogLevelList);
        }

    }
}

