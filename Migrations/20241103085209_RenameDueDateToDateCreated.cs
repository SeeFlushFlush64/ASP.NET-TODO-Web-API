using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TODOWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class RenameDueDateToDateCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DueDate",
                table: "Tasks",
                newName: "DateCreated");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Tasks",
                newName: "DueDate");
        }
    }
}
