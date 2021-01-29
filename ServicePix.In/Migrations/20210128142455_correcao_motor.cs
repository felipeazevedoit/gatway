using Microsoft.EntityFrameworkCore.Migrations;

namespace ServicePix.In.Migrations
{
    public partial class correcao_motor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idMotorAux",
                table: "Parametro");

            migrationBuilder.DropColumn(
                name: "idTipoAcao",
                table: "Parametro");

            migrationBuilder.DropColumn(
                name: "idMotorAux",
                table: "Acao");

            migrationBuilder.AddColumn<int>(
                name: "acaoID",
                table: "MotorAuxiliar",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "parametroID",
                table: "Acao",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "acaoID",
                table: "MotorAuxiliar");

            migrationBuilder.DropColumn(
                name: "parametroID",
                table: "Acao");

            migrationBuilder.AddColumn<int>(
                name: "idMotorAux",
                table: "Parametro",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idTipoAcao",
                table: "Parametro",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idMotorAux",
                table: "Acao",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
