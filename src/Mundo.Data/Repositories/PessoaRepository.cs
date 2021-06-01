using Microsoft.EntityFrameworkCore;
using Mundo.Business.Entity;
using Mundo.Business.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mundo.Data.Repositories
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(MundoContext db) : base(db) { }

        public async Task<IEnumerable<Pessoa>> GetPessoaPets()
        {
            return await Db.Pessoas.AsNoTracking()
                .Include(p => p.Pets)
                .ToListAsync();
        }
    }
}
