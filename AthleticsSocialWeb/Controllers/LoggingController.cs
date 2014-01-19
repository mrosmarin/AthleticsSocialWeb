using System.Web.Mvc;
using AthleticsSocialWeb.Common.Helpers;
using AthleticsSocialWeb.Core.Entities.Logging;
using AthleticsSocialWeb.Models;

namespace AthleticsSocialWeb.Controllers
{

        [Authorize]
        public class LoggingController : Controller
        {
            private readonly ILogReportingFacade loggingRepository;

            public LoggingController()
            {
            //    loggingRepository = new LogReportingFacade();
            }

            public LoggingController(ILogReportingFacade repository)
            {
                loggingRepository = repository;
            }

            /// <summary>
            /// Returns the Index view
            /// </summary>
            /// <param name="period">Text representation of the date time period. eg: Today, Yesterday, Last Week etc.</param>
            /// <param name="loggerProviderName">Elmah, Log4Net, NLog, Health Monitoring etc</param>
            /// <param name="logLevel">Debug, Info, Warning, Error, Fatal</param>
            /// <param name="page">The current page index (0 based)</param>
            /// <param name="pageSize">The number of records per page</param>
            /// <returns></returns>
            public ActionResult Index(string period, string loggerProviderName, string logLevel, int? page, int? pageSize)
            {
                // Set up our default values
                string defaultPeriod = Session["Period"] == null ? "Today" : Session["Period"].ToString();
                string defaultLogType = Session["LoggerProviderName"] == null ? "All" : Session["LoggerProviderName"].ToString();
                string defaultLogLevel = Session["LogLevel"] == null ? "Error" : Session["LogLevel"].ToString();

                // Set up our view model
                var model = new LoggingIndexModel();

                model.Period = (period == null) ? defaultPeriod : period;
                model.LoggerProviderName = (loggerProviderName == null) ? defaultLogType : loggerProviderName;
                model.LogLevel = (logLevel == null) ? defaultLogLevel : logLevel;
                model.CurrentPageIndex = page.HasValue ? page.Value - 1 : 0;
                model.PageSize = pageSize.HasValue ? pageSize.Value : 20;

                TimePeriod timePeriod = TimePeriodHelper.GetUtcTimePeriod(model.Period);

                // Grab the data from the database
                model.LogEvents = loggingRepository.GetByDateRangeAndType(model.CurrentPageIndex, model.PageSize, timePeriod.Start, timePeriod.End, model.LoggerProviderName, model.LogLevel);

                // Put this into the ViewModel so our Pager can get at these values
                ViewData["Period"] = model.Period;
                ViewData["LoggerProviderName"] = model.LoggerProviderName;
                ViewData["LogLevel"] = model.LogLevel;
                ViewData["PageSize"] = model.PageSize;

                // Put the info into the Session so that when we browse away from the page and come back that the last settings are rememberd and used.
                Session["Period"] = model.Period;
                Session["LoggerProviderName"] = model.LoggerProviderName;
                Session["LogLevel"] = model.LogLevel;

                return View(model);
            }
        }
    }

