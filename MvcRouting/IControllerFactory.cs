using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace Artech.MvcRouting
{
    public interface IControllerFactory
    {
        IController CreateController(RequestContext requestContext, string controllorName);
    }
}
