using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AthleticsSocialWeb.Core.Entities.Logging;
using AthleticsSocialWeb.DAL;

namespace AthleticsSocialWeb.Repository
{
    public abstract class AbstractLogEventRepository<TDbContext> : Repository<LogEvent>, ILogReportingRepository where TDbContext : DbContext
    {

        public TDbContext DbContext
        {
            get { return (TDbContext)Context; }
        }


        protected AbstractLogEventRepository(DbContext context)
            : base(context)
        {
        }

        public abstract IQueryable<LogEvent> GetByDateRangeAndType(int pageIndex, int pageSize, DateTime start, DateTime end, string logLevel);
        public abstract LogEvent GetById(string id);
        public abstract void ClearLog(DateTime start, DateTime end, string[] logLevels);
    }
}
