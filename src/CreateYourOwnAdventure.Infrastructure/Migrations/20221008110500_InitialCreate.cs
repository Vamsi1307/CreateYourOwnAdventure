using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreateYourOwnAdventure.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adventures",
                columns: table => new
                {
                    BinaryTreeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Root = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adventures", x => x.BinaryTreeId);
                });

            migrationBuilder.CreateTable(
                name: "MyAdventures",
                columns: table => new
                {
                    MyAdventureId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BinaryTreeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Steps = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyAdventures", x => x.MyAdventureId);
                });

            migrationBuilder.InsertData(
                table: "Adventures",
                columns: new[] { "BinaryTreeId", "Root" },
                values: new object[] { 1, "{\"Yes\":{\"Yes\":{\"Yes\":{\"Data\":{\"Text\":\"Get it\"}},\"No\":{\"Data\":{\"Text\":\"Do jumping jacks first!\"}},\"Data\":{\"Text\":\"Are you sure?\"}},\"No\":{\"Yes\":{\"Data\":{\"Text\":\"What are you waiting for? Grab it now.\"}},\"No\":{\"Data\":{\"Text\":\"Wait till you find a sinful, unforgettable doughnut.\"}},\"Data\":{\"Text\":\"Is it a good donut?\"}},\"Data\":{\"Text\":\"Do I deserve it?\"}},\"No\":{\"Data\":{\"Text\":\"Maybe you want an apple?\"}},\"Data\":{\"Text\":\"Do I want a Donut?\"}}" });

            migrationBuilder.InsertData(
                table: "MyAdventures",
                columns: new[] { "MyAdventureId", "BinaryTreeId", "Steps" },
                values: new object[] { 1, 1, "[\"L\",\"L\",\"R\",\"L\"]" });            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adventures");

            migrationBuilder.DropTable(
                name: "MyAdventures");
        }
    }
}
