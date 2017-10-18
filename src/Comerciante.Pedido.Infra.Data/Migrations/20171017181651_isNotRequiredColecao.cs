using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Comerciante.Pedido.Infra.Data.Migrations
{
    public partial class isNotRequiredColecao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Colecoes_Id_colecao",
                table: "Pedidos");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id_colecao",
                table: "Pedidos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Colecoes_Id_colecao",
                table: "Pedidos",
                column: "Id_colecao",
                principalTable: "Colecoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Colecoes_Id_colecao",
                table: "Pedidos");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id_colecao",
                table: "Pedidos",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Colecoes_Id_colecao",
                table: "Pedidos",
                column: "Id_colecao",
                principalTable: "Colecoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
