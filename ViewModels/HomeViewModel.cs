using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetBooksMVC.Src.DTOs;
using NetBooksMVC.Src.Shared.Errors;

namespace NetBooksMVC.ViewModels
{
    public class HomeViewModel : ErrorMessagesViewModel
    {
        public List<BookItemDTO>? books { get; set; } = null;
    }
}