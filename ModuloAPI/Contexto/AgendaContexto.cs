using Microsoft.EntityFrameworkCore;

namespace ModuloAPI.Contexto
{
    public class AgendaContexto : DbContext
    {
        public AgendaContexto(DbContextOptions<AgendaContexto> options)
            : base(options)
        {
        }

        // Define your DbSets here
        // Example: public DbSet<Usuario> Usuarios { get; set; }
    }
}
