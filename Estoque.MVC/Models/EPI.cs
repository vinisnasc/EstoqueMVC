using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estoque.MVC.Models
{
    public class EPI
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CA { get; set; }
        public int Quantidade { get; set; } = 0;
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Valor { get; set; }
        [Display(Name = "Tempo de uso")]
        public int Validade { get; set; }
        public ICollection<Retirada> FuncionarioEPIs { get; set; } = new List<Retirada>();

        public EPI(int id, string nome, int cA, double valor, int validade)
        {
            Id = id;
            Nome = nome;
            CA = cA;
            Quantidade = 0;
            Valor = valor;
            Validade = validade;
        }

        public EPI()
        {}
    }
}
