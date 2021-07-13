using Microsoft.EntityFrameworkCore;

namespace Agenda_NetCore5_MVC_Ajax.Models
{
    public class Contexto : DbContext
    {
        public DbSet <Tarefa> Tarefas { get; set; }

        public Contexto(DbContextOptions<Contexto> options):base(options)
        {

        }
    }
}
