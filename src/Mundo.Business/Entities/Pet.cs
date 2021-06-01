using Mundo.Business.Entity;
using Mundo.Business.Enums;
using System;

namespace Mundo.Business.Entities
{
    public class Pet : BaseEntity
    {
        public Guid PessoaId { get; set; }
        public string Nome { get; set; }
        public ETipoAnimal Tipo { get; set; }
        public DateTime DataNascimento { get; set; }

        public Pessoa Pessoa { get; set; }
    }
}
