using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiNotes.Migrations
{
    /// <inheritdoc />
    public partial class PopulatingNotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO notes(fk_path, fk_usuario, ds_name, dh_inclusao) VALUES(1, 1, 'Java', now())");
            migrationBuilder.Sql("INSERT INTO notes(fk_path, fk_usuario, ds_name, dh_inclusao) VALUES(2, 2, 'MRM', now())");
            migrationBuilder.Sql("INSERT INTO notes(fk_path, fk_usuario, ds_name, dh_inclusao) VALUES(3, 3, 'English Day', now())");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM notes");
        }
    }
}
