using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetBooksMVC.ViewModels
{
    public class LoginViewModel : ErrorMessagesViewModel
    {

        [Required(ErrorMessage = "Informe o nome do usuário")]
        [Display(Name = "Usuário")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }
        public string? ReturnUrl { get; set; }

    }
}