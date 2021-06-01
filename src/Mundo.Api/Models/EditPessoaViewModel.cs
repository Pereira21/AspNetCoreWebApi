using System;

namespace Mundo.Api.Models
{
    public class EditPessoaViewModel
    {
        public Guid Id { get; set; }
        public DateTime _Insert { get; set; }
        public string Nome { get; set; }
        public decimal? Altura { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
