using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcRouting.Annotations;

namespace Artech.MvcRouting
{
    public class ControllerBuilder
    {
        static ControllerBuilder()
        {
            Current = new ControllerBuilder();
        }

        public static ControllerBuilder Current { get; private set; }

        private static readonly IControllerFactory ControllerFactory = new DefaultControllerFactory();

        public IControllerFactory GetControllerFactory()
        {
            return ControllerFactory;
        }


    }
}
