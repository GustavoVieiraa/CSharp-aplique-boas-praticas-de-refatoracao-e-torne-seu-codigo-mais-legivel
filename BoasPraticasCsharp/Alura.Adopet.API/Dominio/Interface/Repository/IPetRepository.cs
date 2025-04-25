using Alura.Adopet.API.Dominio.Entity;

namespace Alura.Adopet.API.Dominio.Interface.Repository
{
    internal interface IPetRepository
    {
        public Task<List<Pet>> ObterTodos();        
        public Pet ObterPorId(Guid id);
        public Pet Adicionar(Pet _pet);
        public Pet Atualizar(int id, Pet _pet);
        public bool Excluir(Guid id);
    }
}
