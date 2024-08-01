using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiNotes.Migrations
{
    /// <inheritdoc />
    public partial class PopulatingUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO users(ds_email, nr_idade, ds_name, dh_inclusao) VALUES('oaugusto265@gmail.com', 19, 'Otavio Augusto', now())");
            migrationBuilder.Sql("INSERT INTO users(ds_email, nr_idade, ds_name, dh_inclusao) VALUES('joaovitor@gmail.com', 18, 'João Vitor', now())");
            migrationBuilder.Sql("INSERT INTO users(ds_email, nr_idade, ds_name, dh_inclusao) VALUES('arturvaz@gmail.com', 19, 'Artur Vaz', now())");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM users");
        }
    }
}
