﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ringbuch
{
    public class MultibleDataEventArgs
    {
        private object[] _args;

        public MultibleDataEventArgs(params object[] args)
        {
            _args = args;
        }
        public object[] args
        {
            get { return _args; }
        }
    }
}
