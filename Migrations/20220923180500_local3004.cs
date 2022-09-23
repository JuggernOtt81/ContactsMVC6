using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactsMVC6.Migrations
{
    public partial class local3004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Contacts",
                newName: "EmailAddress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Contacts",
                newName: "Email");
        }
    }
}
