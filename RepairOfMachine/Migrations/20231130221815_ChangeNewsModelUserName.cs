using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairOfMachine.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNewsModelUserName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "News");
        }
    }
}
