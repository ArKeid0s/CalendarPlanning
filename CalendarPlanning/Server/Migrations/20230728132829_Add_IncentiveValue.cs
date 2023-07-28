using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalendarPlanning.Server.Migrations
{
    /// <inheritdoc />
    public partial class Add_IncentiveValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IncentiveValues",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UnifocalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProgressiveValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncentiveValues", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncentiveValues",
                schema: "dbo");
        }
    }
}
