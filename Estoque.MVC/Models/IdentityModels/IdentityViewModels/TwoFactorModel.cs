using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.MVC.Models.IdentityModels.IdentityViewModels
{
    public class TwoFactorModel
    {
        [Required]
        public string Token { get; set; }
    }
}
