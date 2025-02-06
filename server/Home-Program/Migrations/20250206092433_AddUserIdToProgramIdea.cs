using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Home_Program.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToProgramIdea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramIdea_AspNetUsers_UserId",
                table: "ProgramIdea");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ProgramIdea",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramIdea_AspNetUsers_UserId",
                table: "ProgramIdea",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramIdea_AspNetUsers_UserId",
                table: "ProgramIdea");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ProgramIdea",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramIdea_AspNetUsers_UserId",
                table: "ProgramIdea",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
