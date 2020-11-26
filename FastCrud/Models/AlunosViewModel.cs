using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastCrud.Models
{
    public class AlunosViewModel
    {
        public AlunosViewModel(IList<Alunos> alunos)
        {

            Alunos = alunos;

            Status = new List<string> { "Ativo", "Inativo", "Todos" };
        }

        public string BuscaAluno { get; set; }

        public List<string> Status { get; set; }
        public IList<Alunos> Alunos { get; private set; }
    }
}
