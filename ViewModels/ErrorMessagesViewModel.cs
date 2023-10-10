using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetBooksMVC.ViewModels
{
    public abstract class ErrorMessagesViewModel
    {
        public IEnumerable<string>? errorMessages { get; set; }

    }
}