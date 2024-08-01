using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

#nullable disable

namespace ApiNotes.Migrations
{
    /// <inheritdoc />
    public partial class PopulatingLogins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO logins(ds_senha, fk_user, ds_name, dh_inclusao) VALUES('123', 1, 'otavio.almeida', now())");
            migrationBuilder.Sql("INSERT INTO logins(ds_senha, fk_user, ds_name, dh_inclusao) VALUES('321', 2, 'joao.vitor', now())");
            migrationBuilder.Sql("INSERT INTO logins(ds_senha, fk_user, ds_name, dh_inclusao) VALUES('132', 3, 'artur.vaz', now())");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM logins");
        }
    }
}
