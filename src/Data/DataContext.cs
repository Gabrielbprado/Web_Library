using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web_Library.Models;

namespace Web_Library.Data
{
    public class DataContext : IdentityDbContext<UserModel>
    {
        public DataContext(DbContextOptions<DataContext> opts) : base(opts)
        {
            
        }
        public DbSet<EmprestimosModel> Emprestimos { get; set; }
    }
}
