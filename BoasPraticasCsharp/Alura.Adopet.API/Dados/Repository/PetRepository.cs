using Alura.Adopet.API.Dados.Context;
using Alura.Adopet.API.Dominio.Entity;
using Alura.Adopet.API.Dominio.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace Alura.Adopet.API.Dados.Repository
{
    internal class PetRepository : IPetRepository
    {
        private DataBaseContext _context;
        public PetRepository(DataBaseContext ctx)
        {
            _context= ctx;
        }
        public Pet Adicionar(Pet _pet)
        {
            _context.Add(_pet);
            _context.SaveChanges();        
            return _pet;
        }

        public Pet Atualizar(int id, Pet _pet)
        {
            var _obj = this.ObterPorId(_pet.Id);
            if (_obj == null)
            {
                return null;
            }
            _context.Entry(_pet).State = EntityState.Modified;
            _context.SaveChanges();
            return _pet;
        }

        public bool Excluir(Guid id)
        {
            var _obj = this.ObterPorId(id);
            if (_obj == null)
            {
                return false;
            }
            _context.Remove(_obj);
            _context.SaveChanges();
            return true;
        }

        public Pet? ObterPorId(Guid id)
        {
            return _context.Pets.Where(a => a.Id == id).FirstOrDefault();
        }

        public async Task<List<Pet>> ObterTodos()
        {
            return await _context.Pets.Include(prop=>prop.Proprietario).ToListAsync();
        }
    }
}
