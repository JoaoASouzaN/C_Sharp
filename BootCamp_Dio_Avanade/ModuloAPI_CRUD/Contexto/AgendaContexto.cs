using Microsoft.EntityFrameworkCore;
using ModuloAPI.Entities;

namespace ModuloAPI.Contexto
{
    public class AgendaContexto : DbContext
    {
        public AgendaContexto(DbContextOptions<AgendaContexto> options)
            : base(options)
        {
        }

        // Example: public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Contato> Contatos { get; set; }
    }
}
