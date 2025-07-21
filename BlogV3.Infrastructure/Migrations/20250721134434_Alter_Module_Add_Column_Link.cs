using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogV3.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Alter_Module_Add_Column_Link : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Modules",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Modules");
        }
    }
}
