using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetBooksMVC.Src.Shared.Errors;

namespace NetBooksMVC.Src.Shared.Handlers
{
    public class DefaultResult<T> where T : class
    {
        public bool IsSuccess { get; set; } = false;
        public T? Data { get; set; }

        public DefaultError? Error { get; set; }


        public DefaultResult()
        {
            IsSuccess = true;
        }

        public DefaultResult(T data)
        {
            IsSuccess = true;
            Data = data;
        }

        public DefaultResult(DefaultError error, T? data)
        {
            Error = error;
            Data = data;
        }
    }
}