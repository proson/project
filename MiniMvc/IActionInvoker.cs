using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniMvc
{
    public interface IActionInvoker
    {
        void InvokeAction(ControllerContext controllerContext, string actionName);
    }
}
