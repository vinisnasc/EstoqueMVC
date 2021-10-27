using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.MVC.Models.InputModels
{
    public class EPIInputModel
    {
        public string Nome { get; set; }
        public int CA { get; set; }
        public int Quantidade { get; set; } = 0;
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Valor { get; set; }
        [Display(Name = "Tempo de uso")]
        public int Validade { get; set; }
    }
}
