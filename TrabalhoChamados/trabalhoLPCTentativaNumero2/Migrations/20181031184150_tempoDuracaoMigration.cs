using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace trabalhoLPCTentativaNumero2.Migrations
{
    public partial class tempoDuracaoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "horaFim",
                table: "Chamados",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<DateTime>(
                name: "tempoDuracao",
                table: "Chamados",
                type: "datetime(6)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tempoDuracao",
                table: "Chamados");

            migrationBuilder.AlterColumn<DateTime>(
                name: "horaFim",
                table: "Chamados",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);
        }
    }
}
