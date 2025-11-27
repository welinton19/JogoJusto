using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JogoJusto.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    InscricaoEstadual = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.EmpresaId);
                });

            migrationBuilder.CreateTable(
                name: "Tokem",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Token = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Expiration = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    TokenId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TokenName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    IdDepartamento = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeDepartamento = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    GerenteId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EmpresaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.IdDepartamento);
                    table.ForeignKey(
                        name: "FK_Departamento_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MetaEsg",
                columns: table => new
                {
                    IdMetaEsg = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TipoMetaEsg = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DescricaoMetaEsg = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ValorReferenciaMetaEsg = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    ValorAtualMetaEsg = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    AtualizacaoDados = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    PrazoMetaEsg = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EmpresaId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaEsg", x => x.IdMetaEsg);
                    table.ForeignKey(
                        name: "FK_MetaEsg_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "EmpresaId");
                });

            migrationBuilder.CreateTable(
                name: "EsgLogModel",
                columns: table => new
                {
                    IdEsgLog = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DepartamentoIdDepartamento = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AcaoRealizada = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Recomendacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataAcao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EsgLogModel", x => x.IdEsgLog);
                    table.ForeignKey(
                        name: "FK_EsgLogModel_Departamento_DepartamentoIdDepartamento",
                        column: x => x.DepartamentoIdDepartamento,
                        principalTable: "Departamento",
                        principalColumn: "IdDepartamento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Genero = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cargo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataContratacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Raca = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    StPcd = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    TipoPcd = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cpf = table.Column<string>(type: "NVARCHAR2(16)", maxLength: 16, nullable: false),
                    CargaHoraria = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DescricaoCargaHoraria = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Salario = table.Column<decimal>(type: "NUMBER(18,2)", nullable: false),
                    MentorFuncionarioId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    DepartamentoIdDepartamento = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.FuncionarioId);
                    table.ForeignKey(
                        name: "FK_Funcionario_Departamento_DepartamentoIdDepartamento",
                        column: x => x.DepartamentoIdDepartamento,
                        principalTable: "Departamento",
                        principalColumn: "IdDepartamento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionario_Funcionario_MentorFuncionarioId",
                        column: x => x.MentorFuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "FuncionarioId");
                });

            migrationBuilder.CreateTable(
                name: "DesenvolvimentoModel",
                columns: table => new
                {
                    IdDesenvolvimento = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TipoRegistro = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DescricaoRegistro = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NomeTreinamento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Treinamento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataConclusao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DuracaoHoras = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Orgao = table.Column<byte[]>(type: "RAW(2000)", nullable: false),
                    DataRegistroDeDados = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    StatusRegistro = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FuncionarioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesenvolvimentoModel", x => x.IdDesenvolvimento);
                    table.ForeignKey(
                        name: "FK_DesenvolvimentoModel_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_EmpresaId",
                table: "Departamento",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_DesenvolvimentoModel_FuncionarioId",
                table: "DesenvolvimentoModel",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_EsgLogModel_DepartamentoIdDepartamento",
                table: "EsgLogModel",
                column: "DepartamentoIdDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_DepartamentoIdDepartamento",
                table: "Funcionario",
                column: "DepartamentoIdDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_MentorFuncionarioId",
                table: "Funcionario",
                column: "MentorFuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_MetaEsg_EmpresaId",
                table: "MetaEsg",
                column: "EmpresaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DesenvolvimentoModel");

            migrationBuilder.DropTable(
                name: "EsgLogModel");

            migrationBuilder.DropTable(
                name: "MetaEsg");

            migrationBuilder.DropTable(
                name: "Tokem");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
