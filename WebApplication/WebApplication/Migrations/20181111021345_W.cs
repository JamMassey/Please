using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class W : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostKey = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 127, nullable: false),
                    PostMessage = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostKey);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Key = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 127, nullable: false),
                    Password = table.Column<string>(maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Key);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Key", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "Password123!", "Customer1@email1.com" },
                    { 2, "Password123!", "Customer1@email2.com" },
                    { 3, "Password123!", "Customer1@email3.com" },
                    { 4, "Password123!", "Customer1@email4.com" },
                    { 5, "Password123!", "Customer1@email5.com" },
                    { 6, "Password123!", "Member1@email.com" }
                });

            migrationBuilder.CreateIndex(
                name: "Key",
                table: "Users",
                column: "Key",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
