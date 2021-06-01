using System;

namespace Mundo.Api.Models
{
    public class CreatePessoaViewModel
    {
        public string Nome { get; set; }
        public decimal? Altura { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
