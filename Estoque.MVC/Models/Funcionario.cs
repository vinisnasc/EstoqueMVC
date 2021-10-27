using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.MVC.Models
{
    public class Funcionario
    {
        [Display(Name = "Registro")]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Funcao { get; set; }
        public ICollection<Retirada> ListaDeEPIs { get; set; } = new List<Retirada>();

        public Funcionario(int id, string nome, string funcao)
        {
            Id = id;
            Nome = nome;
            Funcao = funcao;
        }

        public Funcionario()
        {}
    }
}
