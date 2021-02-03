using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServicePix.In.Migrations
{
    public partial class sqlserver : Migration
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
                    Caminho = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametro", x => x.ID);
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
                    parametroID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acao", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Acao_Parametro_parametroID",
                        column: x => x.parametroID,
                        principalTable: "Parametro",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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
                    acaoID = table.Column<int>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorAuxiliar", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MotorAuxiliar_Acao_acaoID",
                        column: x => x.acaoID,
                        principalTable: "Acao",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acao_parametroID",
                table: "Acao",
                column: "parametroID");

            migrationBuilder.CreateIndex(
                name: "IX_MotorAuxiliar_acaoID",
                table: "MotorAuxiliar",
                column: "acaoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "MotorAuxiliar");

            migrationBuilder.DropTable(
                name: "Acao");

            migrationBuilder.DropTable(
                name: "Parametro");
        }
    }
}
