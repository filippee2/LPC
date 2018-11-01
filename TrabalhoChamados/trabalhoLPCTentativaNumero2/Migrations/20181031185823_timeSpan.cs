using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace trabalhoLPCTentativaNumero2.Migrations
{
    public partial class timeSpan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "tempoDuracao",
                table: "Chamados",
                type: "time(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "tempoDuracao",
                table: "Chamados",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time(6)",
                oldNullable: true);
        }
    }
}
