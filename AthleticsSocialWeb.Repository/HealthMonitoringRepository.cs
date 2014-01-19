﻿using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using AthleticsSocialWeb.Core.Entities.Logging;

namespace AthleticsSocialWeb.Repository
{
    /// <summary>
    /// This class extracts information that ASP.NET Health Monitoring stores so that we can report on it
    /// </summary>
    public class HealthMonitoringRepository : AbstractLogEventRepository<Health>
    {
        /// <summary>
        /// Default Constructor uses the default Entity Container
        /// </summary>
        public HealthMonitoringRepository()
            : base(new Logging())
        {
        }

        /// <summary>
        /// Overloaded constructor that can take an EntityContainer as a parameter so that it can be mocked out by our tests
        /// </summary>
        /// <param name="context">The Entity context</param>
        public HealthMonitoringRepository(DbContext context)
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
            var list = (from h in DbContext.vw_aspnet_WebEvents_extended
                        where h.EventTimeUtc >= start && h.EventTimeUtc <= end
                        && (h.Level == logLevel || logLevel == "All")
                        select new LogEvent
                        {
                            IdType = "string"
                            ,
                            Id = h.EventId
                            ,
                            IdAsInteger = 0
                            ,
                            IdAsGuid = Guid.NewGuid()
                            ,
                            LoggerProviderName = "Health Monitoring"
                            ,
                            LogDate = h.EventTimeUtc
                            ,
                            MachineName = h.MachineName
                            ,
                            Message = h.Message
                            ,
                            Type = h.EventType
                            ,
                            Level = h.Level
                            ,
                            Source = h.RequestUrl
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
            var logEvent = (from b in DbContext.vw_aspnet_WebEvents_extended
                            where b.EventId == id
                            select new LogEvent
                            {
                                IdType = "string"
                                ,
                                Id = b.EventId
                                ,
                                LoggerProviderName = "Health Monitoring"
                                ,
                                LogDate = b.EventTimeUtc
                                ,
                                MachineName = b.MachineName
                                ,
                                Message = b.Message
                                ,
                                Type = b.EventType
                                ,
                                Level = b.Level
                                ,
                                Source = b.RequestUrl
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

            string commandText = "";
            commandText += "DELETE ";
            commandText += "FROM ";
            commandText += "    aspnet_WebEvent_Events ";
            commandText += "WHERE";
            commandText += "    EventId IN    ";
            commandText += "(SELECT EventId    ";
            commandText += " FROM vw_aspnet_WebEvents_extended ";
            commandText += " WHERE ";
            commandText += "    [EventTimeUtc] >= @p0";
            commandText += " AND [EventTimeUtc] <= @p1";
            commandText += " AND [Level] IN (@p2)"; // eg:  AND [Level] IN ('Info','Debug')
            commandText += " )";

            var paramStartDate = new SqlParameter { ParameterName = "p0", Value = start.ToUniversalTime(), DbType = System.Data.DbType.DateTime };
            var paramEndDate = new SqlParameter { ParameterName = "p1", Value = end.ToUniversalTime(), DbType = System.Data.DbType.DateTime };
            var paramLogLevelList = new SqlParameter { ParameterName = "p2", Value = logLevelList };

            DbContext.Database.ExecuteSqlCommand(commandText, paramStartDate, paramEndDate, paramLogLevelList);
        }

    }
}

