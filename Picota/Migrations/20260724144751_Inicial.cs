using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Picota.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Agenda",
                table: "Agenda");

            migrationBuilder.DropColumn(
                name: "Cliente",
                table: "Agenda");

            migrationBuilder.RenameTable(
                name: "Agenda",
                newName: "Agendas");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Agendas",
                newName: "Status");

            migrationBuilder.AddColumn<int>(
                name: "BarbeariaId",
                table: "Clientes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BarbeariaId",
                table: "Agendas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Agendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHora",
                table: "Agendas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Agendas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agendas",
                table: "Agendas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Barbearia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barbearia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DuracaoMinutos = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_BarbeariaId",
                table: "Clientes",
                column: "BarbeariaId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_BarbeariaId",
                table: "Agendas",
                column: "BarbeariaId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_ClienteId",
                table: "Agendas",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Barbearia_BarbeariaId",
                table: "Agendas",
                column: "BarbeariaId",
                principalTable: "Barbearia",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Clientes_ClienteId",
                table: "Agendas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Barbearia_BarbeariaId",
                table: "Clientes",
                column: "BarbeariaId",
                principalTable: "Barbearia",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Barbearia_BarbeariaId",
                table: "Agendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Clientes_ClienteId",
                table: "Agendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Barbearia_BarbeariaId",
                table: "Clientes");

            migrationBuilder.DropTable(
                name: "Barbearia");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_BarbeariaId",
                table: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agendas",
                table: "Agendas");

            migrationBuilder.DropIndex(
                name: "IX_Agendas_BarbeariaId",
                table: "Agendas");

            migrationBuilder.DropIndex(
                name: "IX_Agendas_ClienteId",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "BarbeariaId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "BarbeariaId",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "DataHora",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Agendas");

            migrationBuilder.RenameTable(
                name: "Agendas",
                newName: "Agenda");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Agenda",
                newName: "Data");

            migrationBuilder.AddColumn<string>(
                name: "Cliente",
                table: "Agenda",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agenda",
                table: "Agenda",
                column: "Id");
        }
    }
}
