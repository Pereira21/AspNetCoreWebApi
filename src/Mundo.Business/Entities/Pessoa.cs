using Mundo.Business.Entities;
using System;
using System.Collections.Generic;

namespace Mundo.Business.Entity
{
    public class Pessoa : BaseEntity
    {
        public string Nome { get; set; }
        public decimal? Altura { get; set; }
        public DateTime DataNascimento { get; set; }

        public IEnumerable<Pet> Pets { get; set; }
    }
}
