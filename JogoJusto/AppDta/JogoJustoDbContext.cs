using JogoJusto.Models;
using Microsoft.EntityFrameworkCore;

namespace JogoJusto.AppDta;

public class JogoJustoDbContext : DbContext
{
    public JogoJustoDbContext(DbContextOptions<JogoJustoDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<FuncionarioModel>(entity =>
        {
            // Mapeia o boolean
            entity.Property(e => e.StPcd)
                .HasColumnType("NUMBER(1)")
                .IsRequired();

            // Mapeia o decimal para NUMBER(18,2)
            entity.Property(e => e.Salario)
                .HasColumnType("NUMBER(18,2)")
                .IsRequired();
        });
    }

    public DbSet<UsuarioModel> Usuario { get; set; }
    public DbSet<FuncionarioModel> Funcionario { get; set; }
    public DbSet<DepartamentoModel> Departamento { get; set; }
    public DbSet<DesenvolvimentoModel> Desenvolvimento { get; set; }
    public DbSet<EmpresaModel> Empresa { get; set; }
    public DbSet<MetaEsgModel> MetaEsg { get; set; }
    public DbSet<EsgLogModel> EsgLogModel { get; set; }

    public DbSet<TokenModel> Tokem { get; set; }
}

