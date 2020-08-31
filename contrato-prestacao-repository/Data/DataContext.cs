using contrato_prestacao_models.Contrato;
using contrato_prestacao_models.Prestacao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace contrato_prestacao_repository.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<ContratoModel> Contrato { get; set; }

        public DbSet<PrestacaoModel> Prestacao { get; set; }
    }
}
