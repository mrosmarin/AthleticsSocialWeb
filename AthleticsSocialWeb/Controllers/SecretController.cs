using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AthleticsSocialWeb.Controllers
{
    public class SecretController : Controller
    {
        //
        // GET: /Scret/
       [Authorize]
        public ContentResult Secret()
        {
            return Content("This is a Secret");
        }

        public ContentResult Overt()
        {
            return Content("This is not secret");
        }
	}
}