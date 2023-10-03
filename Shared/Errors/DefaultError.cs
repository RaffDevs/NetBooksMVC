using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetBooksMVC.Src.Shared.Errors
{
    public class DefaultError : Exception
    {
        public DefaultError() { }

        public DefaultError(string errorMessage) : base(errorMessage) { }

        public DefaultError(string errorMessage, Exception exception) : base(errorMessage, exception) { }
    }
}