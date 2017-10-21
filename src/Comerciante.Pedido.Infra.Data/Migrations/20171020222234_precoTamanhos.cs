using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Comerciante.Pedido.Infra.Data.Migrations
{
    public partial class precoTamanhos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Referencia_Tamanhos");

            migrationBuilder.AddColumn<double>(
                name: "Preco",
                table: "Referencia_Tamanhos",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Referencia_Tamanhos");

            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "Referencia_Tamanhos",
                nullable: true);
        }
    }
}
