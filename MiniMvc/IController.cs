﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniMvc
{
    public interface IController
    {
        void Execute(RequestContext requestContext);
    }
}
