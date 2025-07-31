using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogV3.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Alter_Role_Add_Column_Status : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Roles",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "activ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Roles");
        }
    }
}
