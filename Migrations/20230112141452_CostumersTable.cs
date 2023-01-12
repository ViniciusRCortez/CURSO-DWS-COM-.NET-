using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace note_one_api.Migrations
{
    public partial class CostumersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Costumers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Credit = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costumers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "Credit", "Email", "Name", "PhoneNumber" },
                values: new object[] { 1, -10.5, "viniciusfake@gmail.com", "Vinicius Cortêz", "+55 (85) 11111-1111" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "Credit", "Email", "Name", "PhoneNumber" },
                values: new object[] { 2, 1984.0, "iamnotbatman@gmail.com", "Bruce Wayne", "+55 (85) 22222-2222" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "Credit", "Email", "Name", "PhoneNumber" },
                values: new object[] { 3, 451.0, "iamironman@gmail.com", "Antony Stark", "+55 (85) 33333-3333" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "Credit", "Email", "Name", "PhoneNumber" },
                values: new object[] { 4, -200.88999999999999, "iamnotmiranha@gmail.com", "Peter Parker", "+21 (44) 44444-4444" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Costumers");
        }
    }
}
