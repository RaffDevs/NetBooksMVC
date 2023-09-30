using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetBooksMVC.Src.Constants;

namespace NetBooksMVC.Src.Shared.Extensions
{
    public static class SearchBookParamsExtensions
    {
        public static string ToLowerCaseString(this SearchBookParams searchParams)
        {
            return searchParams.ToString().ToLower();
        }
    }
}