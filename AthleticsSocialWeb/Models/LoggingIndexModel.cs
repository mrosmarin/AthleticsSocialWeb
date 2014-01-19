using AthleticsSocialWeb.Common.Paging;
using AthleticsSocialWeb.Core.Entities.Logging;

namespace AthleticsSocialWeb.Models
{
    public class LoggingIndexModel
    {
        public IPagedList<LogEvent> LogEvents { get; set; }

        public string LoggerProviderName { get; set; }
        public string LogLevel { get; set; }
        public string Period { get; set; }

        public int CurrentPageIndex { get; set; }
        public int PageSize { get; set; }

        public LoggingIndexModel()
        {
            CurrentPageIndex = 0;
            PageSize = 20;
        }
    }
}
