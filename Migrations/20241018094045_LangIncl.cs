using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssignmentWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class LangIncl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "AssignmentSubmission",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "AssignmentSubmission");
        }
    }
}
