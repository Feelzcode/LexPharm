using Microsoft.EntityFrameworkCore.Migrations;

namespace LexPharm.Migrations
{
    public partial class AddChangesToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(nullable: true),
                    Generic = table.Column<string>(nullable: true),
                    ProductNo = table.Column<int>(nullable: false),
                    drugImages = table.Column<string>(nullable: true),
                    dosage = table.Column<string>(nullable: true),
                    Form = table.Column<string>(nullable: true),
                    ExpiryDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drugs");
        }
    }
}
