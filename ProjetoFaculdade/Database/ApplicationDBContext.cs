using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFaculdade.API.Database
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) {}

        public virtual DbSet<tb_dados> tb_dados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "server=localhost;port=3306;database=mysql_hml;uid=root;password=123Mudar@";
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tb_dados>().ToTable("tb_dados");
            modelBuilder.Entity<tb_dados>().HasKey(p => p.id);
            modelBuilder.Entity<tb_dados>().Property(p => p.mensagem).HasColumnType("varchar(100)");
        }
    }

    public class tb_dados
    {
        public int id { get; set; }
        public string mensagem { get; set; }
    }
}
