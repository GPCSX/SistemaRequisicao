using Microsoft.EntityFrameworkCore;
using SistemaRequisicao.Data.Map;
using SistemaRequisicao.Models;
using System.Security.Cryptography.X509Certificates;

namespace SistemaRequisicao.Data
{
    public class SistemaRequisicaoDBContext : DbContext
    {
        public SistemaRequisicaoDBContext(DbContextOptions<SistemaRequisicaoDBContext> options)
            : base(options)
        {
        }
        public DbSet<TarefaModel> Tarefa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
