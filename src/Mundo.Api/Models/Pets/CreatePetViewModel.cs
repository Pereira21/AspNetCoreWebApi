using Mundo.Business.Enums;
using System;

namespace Mundo.Api.Models.Pets
{
    public class CreatePetViewModel
    {
        public Guid PessoaId { get; set; }
        public string Nome { get; set; }
        public ETipoAnimal Tipo { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
