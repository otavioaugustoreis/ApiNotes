using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiNotes.Migrations
{
    /// <inheritdoc />
    public partial class PopulatingPaths : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO paths(ds_descricao, fk_usuario, ds_name, dh_inclusao) VALUES('Aqui vai ser apenas para estudos', 1, 'Estudos', now())");
            migrationBuilder.Sql("INSERT INTO paths(ds_descricao, fk_usuario, ds_name, dh_inclusao) VALUES('Aqui vai ser apenas para Trabalho', 2, 'Trabalho', now())");
            migrationBuilder.Sql("INSERT INTO paths(ds_descricao, fk_usuario, ds_name, dh_inclusao) VALUES('Aqui vai ser apenas para inglês', 2, 'Inglês', now())");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM paths");
        }
    }
}
