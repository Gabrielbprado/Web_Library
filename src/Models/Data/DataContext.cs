using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Web_Library.Models;

namespace Web_Library.Data
{
    public class DataContext : IdentityDbContext<UserModel>
    {
        public DataContext(DbContextOptions<DataContext> opts) : base(opts)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Chame o método da classe base primeiro

            modelBuilder.Entity<EmprestimosModel>()
                .HasOne(e => e.UserModel)
                .WithMany(u => u.EmprestimosModel) // Corrija a configuração para WithMany
                .HasForeignKey(e => e.FuncionarioId); // Use FuncionarioId como chave estrangeira

            // Outras configurações de modelo...
        }
        public DbSet<EmprestimosModel> Emprestimos { get; set; }
    }
}
