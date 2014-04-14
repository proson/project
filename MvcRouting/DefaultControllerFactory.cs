using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Artech.MvcRouting
{
    public class DefaultControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            RouteData routeData = requestContext.RouteData;
            string controllerType = string.Format("{0}Controller", controllerName);
            IController controller = this.CreateController(controllerType);
            if (controller != null)
            {
                return controller;
            }
            foreach (string assembly in routeData.Assemblies)
            {
                controller = this.CreateController(controllerType, assembly);
                if (controller != null)
                {
                    return controller;
                }
                foreach (string ns in routeData.Namespaces)
                {
                    controllerType = string.Format("{0}.{1}Controller", ns, controllerName);
                    controller = CreateController(controllerType, assembly);
                    if (controller != null)
                    {
                        return controller;
                    }
                }
            }
            throw new InvalidOperationException("Cannot locate the controller");
        }

        private IController CreateController(string controllerType, string assembly = null)
        {
            Type type = null;
            if (null == assembly)
            {
                type = Type.GetType(controllerType);
            }
            else
            {
                type = Assembly.Load(assembly).GetType(controllerType);
            }
            if (null == type)
            {
                return null;
            }
            return Activator.CreateInstance(type) as IController;
        }
    }
}
