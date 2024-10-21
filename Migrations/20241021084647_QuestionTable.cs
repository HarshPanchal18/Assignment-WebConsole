using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssignmentWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class QuestionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Assignments_AssignmentId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "UpdationTimestamp",
                table: "Questions",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DeletionTimestamp",
                table: "Questions",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Questions",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "CreationTimestamp",
                table: "Questions",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Questions",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AssignmentId",
                table: "Questions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Questions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Assignments_AssignmentId",
                table: "Questions",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Assignments_AssignmentId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Questions",
                newName: "UpdationTimestamp");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Questions",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Questions",
                newName: "DeletionTimestamp");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Questions",
                newName: "CreationTimestamp");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Questions",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<int>(
                name: "AssignmentId",
                table: "Questions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Assignments_AssignmentId",
                table: "Questions",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id");
        }
    }
}
