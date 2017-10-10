using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Comerciante.Pedido.Infra.Data.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colecoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AtualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CriadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true),
                    DeletadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colecoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AtualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CriadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true),
                    DeletadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AtualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CriadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true),
                    DeletadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Referencias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AtualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CriadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true),
                    DeletadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grade = table.Column<bool>(type: "bit", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referencias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tamanhos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AtualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CriadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true),
                    DeletadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tamanhos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AtualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CriadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true),
                    DeletadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_cliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_colecao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Contas_Id_cliente",
                        column: x => x.Id_cliente,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Colecoes_Id_colecao",
                        column: x => x.Id_colecao,
                        principalTable: "Colecoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Referencia_Colecoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AtualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CriadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true),
                    DeletadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_colecao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_referencia = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referencia_Colecoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Referencia_Colecoes_Colecoes_Id_colecao",
                        column: x => x.Id_colecao,
                        principalTable: "Colecoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Referencia_Colecoes_Referencias_Id_referencia",
                        column: x => x.Id_referencia,
                        principalTable: "Referencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Referencia_Cores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AtualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CriadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true),
                    DeletadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_cor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_referencia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referencia_Cores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Referencia_Cores_Cores_Id_cor",
                        column: x => x.Id_cor,
                        principalTable: "Cores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Referencia_Cores_Referencias_Id_referencia",
                        column: x => x.Id_referencia,
                        principalTable: "Referencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Referencia_Imagens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AtualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CriadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true),
                    DeletadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_referencia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referencia_Imagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Referencia_Imagens_Referencias_Id_referencia",
                        column: x => x.Id_referencia,
                        principalTable: "Referencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Referencia_Tamanhos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AtualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CriadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true),
                    DeletadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_referencia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_tamanho = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referencia_Tamanhos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Referencia_Tamanhos_Referencias_Id_referencia",
                        column: x => x.Id_referencia,
                        principalTable: "Referencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Referencia_Tamanhos_Tamanhos_Id_tamanho",
                        column: x => x.Id_tamanho,
                        principalTable: "Tamanhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedido_Referencias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AtualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CriadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true),
                    DeletadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_pedido = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_referencia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido_Referencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Referencias_Pedidos_Id_pedido",
                        column: x => x.Id_pedido,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_Referencias_Referencias_Id_referencia",
                        column: x => x.Id_referencia,
                        principalTable: "Referencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedido_Referencia_Tamanhos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AtualizadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CriadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: true),
                    DeletadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_pedido_referencia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_referencia_cor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_referencia_tamanho = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido_Referencia_Tamanhos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Referencia_Tamanhos_Pedido_Referencias_Id_pedido_referencia",
                        column: x => x.Id_pedido_referencia,
                        principalTable: "Pedido_Referencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_Referencia_Tamanhos_Referencia_Cores_Id_referencia_cor",
                        column: x => x.Id_referencia_cor,
                        principalTable: "Referencia_Cores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedido_Referencia_Tamanhos_Referencia_Tamanhos_Id_referencia_tamanho",
                        column: x => x.Id_referencia_tamanho,
                        principalTable: "Referencia_Tamanhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_Referencia_Tamanhos_Id_pedido_referencia",
                table: "Pedido_Referencia_Tamanhos",
                column: "Id_pedido_referencia");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_Referencia_Tamanhos_Id_referencia_cor",
                table: "Pedido_Referencia_Tamanhos",
                column: "Id_referencia_cor");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_Referencia_Tamanhos_Id_referencia_tamanho",
                table: "Pedido_Referencia_Tamanhos",
                column: "Id_referencia_tamanho");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_Referencias_Id_pedido",
                table: "Pedido_Referencias",
                column: "Id_pedido");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_Referencias_Id_referencia",
                table: "Pedido_Referencias",
                column: "Id_referencia");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_Id_cliente",
                table: "Pedidos",
                column: "Id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_Id_colecao",
                table: "Pedidos",
                column: "Id_colecao");

            migrationBuilder.CreateIndex(
                name: "IX_Referencia_Colecoes_Id_colecao",
                table: "Referencia_Colecoes",
                column: "Id_colecao");

            migrationBuilder.CreateIndex(
                name: "IX_Referencia_Colecoes_Id_referencia",
                table: "Referencia_Colecoes",
                column: "Id_referencia");

            migrationBuilder.CreateIndex(
                name: "IX_Referencia_Cores_Id_cor",
                table: "Referencia_Cores",
                column: "Id_cor");

            migrationBuilder.CreateIndex(
                name: "IX_Referencia_Cores_Id_referencia",
                table: "Referencia_Cores",
                column: "Id_referencia");

            migrationBuilder.CreateIndex(
                name: "IX_Referencia_Imagens_Id_referencia",
                table: "Referencia_Imagens",
                column: "Id_referencia");

            migrationBuilder.CreateIndex(
                name: "IX_Referencia_Tamanhos_Id_referencia",
                table: "Referencia_Tamanhos",
                column: "Id_referencia");

            migrationBuilder.CreateIndex(
                name: "IX_Referencia_Tamanhos_Id_tamanho",
                table: "Referencia_Tamanhos",
                column: "Id_tamanho");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedido_Referencia_Tamanhos");

            migrationBuilder.DropTable(
                name: "Referencia_Colecoes");

            migrationBuilder.DropTable(
                name: "Referencia_Imagens");

            migrationBuilder.DropTable(
                name: "Pedido_Referencias");

            migrationBuilder.DropTable(
                name: "Referencia_Cores");

            migrationBuilder.DropTable(
                name: "Referencia_Tamanhos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Cores");

            migrationBuilder.DropTable(
                name: "Referencias");

            migrationBuilder.DropTable(
                name: "Tamanhos");

            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.DropTable(
                name: "Colecoes");
        }
    }
}
