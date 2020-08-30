using contrato_prestacao_models.Contrato;
using Microsoft.EntityFrameworkCore;

namespace contrato_prestacao_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<ContratoModel> Contrato { get; set; }
    }
}
