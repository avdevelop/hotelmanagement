using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;
using System.IO;

namespace HotelManagement.Tests.TestHelpers
{
    public static class MvcMockHelpers
    {
        public static void AddMockHttpContext(this Controller controller)
        {
            HttpRequest req = new HttpRequest("test", "http://test", "");
            HttpResponse res = new HttpResponse(new StringWriter());
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new HttpContextWrapper(new HttpContext(req, res));
        }
    }
}
