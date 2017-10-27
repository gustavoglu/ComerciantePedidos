using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Comerciante.Pedido.Infra.Data.Migrations
{
    public partial class pedidoFinalizado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Referencia_Tamanhos_Pedido_Referencias_Id_pedido_referencia",
                table: "Pedido_Referencia_Tamanhos");

            migrationBuilder.AddColumn<bool>(
                name: "Finalizado",
                table: "Pedidos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Referencia_Tamanhos_Pedido_Referencias_Id_pedido_referencia",
                table: "Pedido_Referencia_Tamanhos",
                column: "Id_pedido_referencia",
                principalTable: "Pedido_Referencias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Referencia_Tamanhos_Pedido_Referencias_Id_pedido_referencia",
                table: "Pedido_Referencia_Tamanhos");

            migrationBuilder.DropColumn(
                name: "Finalizado",
                table: "Pedidos");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Referencia_Tamanhos_Pedido_Referencias_Id_pedido_referencia",
                table: "Pedido_Referencia_Tamanhos",
                column: "Id_pedido_referencia",
                principalTable: "Pedido_Referencias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
