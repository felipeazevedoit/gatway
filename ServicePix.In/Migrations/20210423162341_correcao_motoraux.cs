using Microsoft.EntityFrameworkCore.Migrations;

namespace ServicePix.In.Migrations
{
    public partial class correcao_motoraux : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acao_Parametro_parametroID",
                table: "Acao");

            migrationBuilder.DropForeignKey(
                name: "FK_MotorAuxiliar_Acao_acaoID",
                table: "MotorAuxiliar");

            migrationBuilder.DropIndex(
                name: "IX_MotorAuxiliar_acaoID",
                table: "MotorAuxiliar");

            migrationBuilder.DropIndex(
                name: "IX_Acao_parametroID",
                table: "Acao");

            migrationBuilder.DropColumn(
                name: "Caminho",
                table: "Parametro");

            migrationBuilder.DropColumn(
                name: "acaoID",
                table: "MotorAuxiliar");

            migrationBuilder.DropColumn(
                name: "parametroID",
                table: "Acao");

            migrationBuilder.AddColumn<int>(
                name: "AcaoID",
                table: "Parametro",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ordem",
                table: "Parametro",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Parametro",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parametro_AcaoID",
                table: "Parametro",
                column: "AcaoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Parametro_Acao_AcaoID",
                table: "Parametro",
                column: "AcaoID",
                principalTable: "Acao",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parametro_Acao_AcaoID",
                table: "Parametro");

            migrationBuilder.DropIndex(
                name: "IX_Parametro_AcaoID",
                table: "Parametro");

            migrationBuilder.DropColumn(
                name: "AcaoID",
                table: "Parametro");

            migrationBuilder.DropColumn(
                name: "Ordem",
                table: "Parametro");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Parametro");

            migrationBuilder.AddColumn<string>(
                name: "Caminho",
                table: "Parametro",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "acaoID",
                table: "MotorAuxiliar",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "parametroID",
                table: "Acao",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MotorAuxiliar_acaoID",
                table: "MotorAuxiliar",
                column: "acaoID");

            migrationBuilder.CreateIndex(
                name: "IX_Acao_parametroID",
                table: "Acao",
                column: "parametroID");

            migrationBuilder.AddForeignKey(
                name: "FK_Acao_Parametro_parametroID",
                table: "Acao",
                column: "parametroID",
                principalTable: "Parametro",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MotorAuxiliar_Acao_acaoID",
                table: "MotorAuxiliar",
                column: "acaoID",
                principalTable: "Acao",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
