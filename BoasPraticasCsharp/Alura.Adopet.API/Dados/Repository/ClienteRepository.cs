using Alura.Adopet.API.Dados.Context;
using Alura.Adopet.API.Dominio.Entity;
using Alura.Adopet.API.Dominio.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace Alura.Adopet.API.Dados.Repository
{
    internal class ClienteRepository : IClienteRepository
    {
        private DataBaseContext _context;
        public ClienteRepository(DataBaseContext ctx)
        {
            _context= ctx;
        }
        public Cliente Adicionar(Cliente _cliente)
        {
            _context.Add(_cliente);
            _context.SaveChanges();        
            return _cliente;
        }

        public Cliente Atualizar(int id, Cliente _cliente)
        {
            var _obj = this.ObterPorId(_cliente.Id);
            if (_obj == null)
            {
                return null;
            }
            _context.Entry(_cliente).State = EntityState.Modified;
            _context.SaveChanges();
            return _obj;
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

        public Cliente? ObterPorId(Guid id)
        {
            return _context.Clientes.Where(a => a.Id == id).FirstOrDefault();
        }

        public List<Cliente> ObterTodos()
        {
            return _context.Clientes.ToList();
        }
    }
}
