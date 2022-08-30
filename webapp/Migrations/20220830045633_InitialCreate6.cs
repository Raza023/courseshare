using Microsoft.EntityFrameworkCore.Migrations;

namespace webapp.Migrations
{
    public partial class InitialCreate6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    courseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    courseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    courseThumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    coursePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    videos = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
