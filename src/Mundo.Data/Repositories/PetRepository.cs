using Mundo.Business.Entities;
using Mundo.Business.Interfaces;

namespace Mundo.Data.Repositories
{
    public class PetRepository : Repository<Pet>, IPetRepository
    {
        public PetRepository(MundoContext db) : base(db) { }
    }
}
