using JogoJusto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JogoJusto.AppDta;

public class JogoJustoDbContext : DbContext
{
    internal readonly object Token;

    public JogoJustoDbContext(DbContextOptions<JogoJustoDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var boolToSN = new ValueConverter<bool, string>(
            v => v ? "S" : "N",
            v => string.Equals(v, "S", StringComparison.OrdinalIgnoreCase));


        modelBuilder.Entity<FuncionarioModel>(entity =>
        {
        entity.ToTable("T_FUNCIONARIO");

            entity.Property(e => e.StPcd)
                .HasConversion(boolToSN)
                .HasMaxLength(1)
                .HasColumnType("CHAR(1)")
                .IsRequired();
            
            // Mapeia o decimal para NUMBER(18,2)
            entity.Property(e => e.Salario)
                .HasColumnType("NUMBER(18,2)")
                .IsRequired();
        });


        modelBuilder.Entity<UsuarioModel>(entity =>
        {
            entity.ToTable("T_USUARIO");
        });

        modelBuilder.Entity<TokenModel>(entity =>
        {
            entity.ToTable("T_TOKENS");
        });

        modelBuilder.Entity<FuncionarioModel>(entity =>
        {
            entity.ToTable("T_FUNCIONARIO");
        });

        modelBuilder.Entity<DepartamentoModel>(entity =>
        {
            entity.ToTable("T_DEPTO");
        });

        modelBuilder.Entity<DesenvolvimentoModel>(entity =>
        {
            entity.ToTable("T_DESENV");
        });

        modelBuilder.Entity<EmpresaModel>(entity =>
        {
            entity.ToTable("T_EMPRESA");
        });

        modelBuilder.Entity<MetaEsgModel>(entity =>
        {
            entity.ToTable("T_META_ESG");
        });

        modelBuilder.Entity<EsgLogModel>(entity =>
        {
            entity.ToTable("T_ESG_LOG");
        });

    }

    public virtual DbSet<UsuarioModel> Usuario { get; set; }
    public virtual DbSet<FuncionarioModel> Funcionario { get; set; }
    public virtual DbSet<DepartamentoModel> Departamento { get; set; }
    public virtual DbSet<DesenvolvimentoModel> Desenvolvimento { get; set; }
    public virtual DbSet<EmpresaModel> Empresa { get; set; }
    public virtual DbSet<MetaEsgModel> MetaEsg { get; set; }
    public virtual DbSet<EsgLogModel> EsgLogModel { get; set; }

    public virtual DbSet<TokenModel> Tokem { get; set; }
}

