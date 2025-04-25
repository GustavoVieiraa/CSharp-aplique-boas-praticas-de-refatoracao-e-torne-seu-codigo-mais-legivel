using System.ComponentModel.DataAnnotations;

namespace Alura.Adopet.API.Dominio.Entity
{
    internal class Cliente
    {
        public Cliente()
        {
           this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        //public ICollection<Pet>? Pets { get; set; }
    }
}
