using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiNotes.Migrations
{
    /// <inheritdoc />
    public partial class AdjustmentOfTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    pk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ds_email = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nr_idade = table.Column<int>(type: "int", nullable: false),
                    ds_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dh_inclusao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.pk_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    pk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ds_senha = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fk_user = table.Column<int>(type: "int", nullable: false),
                    ds_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dh_inclusao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.pk_id);
                    table.ForeignKey(
                        name: "FK_Logins_Users_fk_user",
                        column: x => x.fk_user,
                        principalTable: "Users",
                        principalColumn: "pk_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Paths",
                columns: table => new
                {
                    pk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ds_descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fk_usuario = table.Column<int>(type: "int", nullable: false),
                    ds_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dh_inclusao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paths", x => x.pk_id);
                    table.ForeignKey(
                        name: "FK_Paths_Users_fk_usuario",
                        column: x => x.fk_usuario,
                        principalTable: "Users",
                        principalColumn: "pk_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    pk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fk_path = table.Column<int>(type: "int", nullable: false),
                    fk_usuario = table.Column<int>(type: "int", nullable: false),
                    ds_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dh_inclusao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.pk_id);
                    table.ForeignKey(
                        name: "FK_Notes_Paths_fk_path",
                        column: x => x.fk_path,
                        principalTable: "Paths",
                        principalColumn: "pk_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notes_Users_fk_usuario",
                        column: x => x.fk_usuario,
                        principalTable: "Users",
                        principalColumn: "pk_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_fk_user",
                table: "Logins",
                column: "fk_user",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_fk_path",
                table: "Notes",
                column: "fk_path");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_fk_usuario",
                table: "Notes",
                column: "fk_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Paths_fk_usuario",
                table: "Paths",
                column: "fk_usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Paths");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
