using Microsoft.EntityFrameworkCore.Migrations;

namespace DeveloperCodingTest.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MembershipType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Membership",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    MembershipTypeId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    AccountBalance = table.Column<decimal>(type: "decimal(9,4)", precision: 9, scale: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membership", x => new { x.PersonId, x.MembershipTypeId });
                    table.ForeignKey(
                        name: "FK_Membership_MembershipType_MembershipTypeId",
                        column: x => x.MembershipTypeId,
                        principalTable: "MembershipType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Membership_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MembershipType",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Primary" },
                    { 2, "Secondary" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Email", "ForeName", "SurName" },
                values: new object[,]
                {
                    { 1, "Aaaaa@Xxxxx.com", "Aaaaa", "Xxxxx" },
                    { 2, "Bbbbb@Yyyyy.com", "Bbbbb", "Yyyyy" },
                    { 3, "Ccccc@Zzzzz.com", "Ccccc", "Zzzzz" }
                });

            migrationBuilder.InsertData(
                table: "Membership",
                columns: new[] { "MembershipTypeId", "PersonId", "AccountBalance", "Number" },
                values: new object[,]
                {
                    { 1, 1, 10.45m, 111 },
                    { 2, 1, 11.45m, 111 },
                    { 1, 2, 12.00m, 333 },
                    { 1, 3, 12.00m, 444 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Membership_MembershipTypeId",
                table: "Membership",
                column: "MembershipTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Membership");

            migrationBuilder.DropTable(
                name: "MembershipType");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
