using System;
using System.Collections.Generic;

namespace FastCrud.Models
{
    public partial class Alunos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime? DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Matricula { get; set; }
        public bool Ativo { get; set; }
    }
}
