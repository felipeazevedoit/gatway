using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServicePix.In.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: true),
                    Descricao = table.Column<string>(maxLength: 150, nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DateAlteracao = table.Column<DateTime>(nullable: false),
                    UsuarioCriacao = table.Column<int>(nullable: false),
                    UsuarioEdicao = table.Column<int>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    idCliente = table.Column<int>(nullable: false),
                    CNPJ = table.Column<string>(maxLength: 150, nullable: true),
                    Email = table.Column<string>(maxLength: 150, nullable: true),
                    Url = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MotorAuxiliar",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: true),
                    Descricao = table.Column<string>(maxLength: 150, nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DateAlteracao = table.Column<DateTime>(nullable: false),
                    UsuarioCriacao = table.Column<int>(nullable: false),
                    UsuarioEdicao = table.Column<int>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    idCliente = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorAuxiliar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Acao",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: true),
                    Descricao = table.Column<string>(maxLength: 150, nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DateAlteracao = table.Column<DateTime>(nullable: false),
                    UsuarioCriacao = table.Column<int>(nullable: false),
                    UsuarioEdicao = table.Column<int>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    idCliente = table.Column<int>(nullable: false),
                    idTipoAcao = table.Column<int>(nullable: false),
                    Caminho = table.Column<string>(nullable: true),
                    MotorAuxiliarID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acao", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Acao_MotorAuxiliar_MotorAuxiliarID",
                        column: x => x.MotorAuxiliarID,
                        principalTable: "MotorAuxiliar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parametro",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: true),
                    Descricao = table.Column<string>(maxLength: 150, nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DateAlteracao = table.Column<DateTime>(nullable: false),
                    UsuarioCriacao = table.Column<int>(nullable: false),
                    UsuarioEdicao = table.Column<int>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    idCliente = table.Column<int>(nullable: false),
                    Ordem = table.Column<int>(nullable: false),
                    Tipo = table.Column<string>(nullable: true),
                    AcaoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametro", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Parametro_Acao_AcaoID",
                        column: x => x.AcaoID,
                        principalTable: "Acao",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acao_MotorAuxiliarID",
                table: "Acao",
                column: "MotorAuxiliarID");

            migrationBuilder.CreateIndex(
                name: "IX_Parametro_AcaoID",
                table: "Parametro",
                column: "AcaoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Parametro");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Acao");

            migrationBuilder.DropTable(
                name: "MotorAuxiliar");
        }
    }
}
