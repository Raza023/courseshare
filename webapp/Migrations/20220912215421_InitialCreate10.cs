using Microsoft.EntityFrameworkCore.Migrations;

namespace webapp.Migrations
{
    public partial class InitialCreate10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_SellerId",
                table: "Courses",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Sellers_SellerId",
                table: "Courses",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Sellers_SellerId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_SellerId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Courses");
        }
    }
}
