using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AvaliaçãoG1.Migrations
{
    public partial class initialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlanosDeSaude",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descricao = table.Column<string>(type: "longtext", nullable: true),
                    nome = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanosDeSaude", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    dataNascimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    email = table.Column<string>(type: "longtext", nullable: true),
                    endereco = table.Column<string>(type: "longtext", nullable: true),
                    isParticular = table.Column<bool>(type: "bit", nullable: false),
                    nome = table.Column<string>(type: "longtext", nullable: true),
                    planoSaudeid = table.Column<int>(type: "int", nullable: true),
                    telefone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pacientes_PlanosDeSaude_planoSaudeid",
                        column: x => x.planoSaudeid,
                        principalTable: "PlanosDeSaude",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    descricao = table.Column<string>(type: "longtext", nullable: true),
                    isPrimeira = table.Column<bool>(type: "bit", nullable: false),
                    pacienteid = table.Column<int>(type: "int", nullable: true),
                    valor = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Consultas_Pacientes_pacienteid",
                        column: x => x.pacienteid,
                        principalTable: "Pacientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_pacienteid",
                table: "Consultas",
                column: "pacienteid");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_planoSaudeid",
                table: "Pacientes",
                column: "planoSaudeid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "PlanosDeSaude");
        }
    }
}
