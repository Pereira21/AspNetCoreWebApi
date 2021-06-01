using Mundo.Business.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mundo.Business.Interfaces
{
    public interface IPessoaRepository : IRepository<Pessoa>
    {
        Task<IEnumerable<Pessoa>> GetPessoaPets();
    }
}
