using System;
using System.Web.Mvc;
using AthleticsSocialWeb.Common;
using AthleticsSocialWeb.Common.Logging;

namespace AthleticsSocialWeb.Controllers
{
    public class SecretController : Controller
    {
        public ILogger Logger { get; set; }

        public SecretController(ILogger logger)
        {
            Logger = logger;
        }

        //
        // GET: /Scret/
       [Authorize]
        public ContentResult Secret()
       {
           //Logger.Info("This is test");
            return Content("This is a Secret");
        }

        public ContentResult Overt()
        {
            Logger.Fatal("this log4net1 logger");
            Logger.Error("this log4net1 logger");
            Logger.Warning("this log4net1 logger");
            Logger.Info("this log4net1 logger");
            Logger.Debug("this log4net1 logger");

            //Logger.Debug("this is a test Ilogger");
            return Content("This is not secret");
        }

        public ContentResult ErrorTest()
        {
            throw new Exception("let see what happens");
            return Content("This is not secret"); 
        }

	}
}