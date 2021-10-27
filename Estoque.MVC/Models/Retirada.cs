using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.MVC.Models
{
    public class Retirada
    {
        public int Id { get; set; }
        public EPI Epi { get; set; }
        public int IdEpi { get; set; }
        public Funcionario Funcionario { get; set; }
        public int IdFuncionario { get; set; }
        public DateTime DataRetirada { get; set; }
        public DateTime Validade { get; set; }

        public Retirada(int id, EPI epi, Funcionario funcionario, DateTime dataRetirada)
        {
            Id = id;
            Epi = epi;
            Funcionario = funcionario;
            DataRetirada = dataRetirada;
            Validade = dataRetirada.AddMonths(epi.Validade);
        }

        public Retirada()
        {}
    }
}
