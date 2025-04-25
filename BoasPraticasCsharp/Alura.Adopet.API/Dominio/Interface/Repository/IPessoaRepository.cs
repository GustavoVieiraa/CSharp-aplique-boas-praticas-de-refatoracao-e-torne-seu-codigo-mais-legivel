using Alura.Adopet.API.Dominio.Entity;

namespace Alura.Adopet.API.Dominio.Interface.Repository
{
    internal interface IClienteRepository
    {
        public List<Cliente> ObterTodos();
        public Cliente ObterPorId(Guid id);
        public Cliente Adicionar(Cliente _pessoa);
        public Cliente Atualizar(int id, Cliente _pessoa);
        public bool Excluir(Guid id);
    }
}
