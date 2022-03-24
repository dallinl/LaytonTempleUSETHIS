using Microsoft.EntityFrameworkCore.Migrations;

namespace LaytonTemple.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvailableTimes",
                columns: table => new
                {
                    TimeSlot = table.Column<string>(nullable: false),
                    GroupID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableTimes", x => x.TimeSlot);
                });

            migrationBuilder.CreateTable(
                name: "GroupInfo",
                columns: table => new
                {
                    GroupID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    groupName = table.Column<string>(nullable: false),
                    groupSize = table.Column<int>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    phone = table.Column<string>(nullable: false),
                    timeslot = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupInfo", x => x.GroupID);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    groupinfoGroupID = table.Column<int>(nullable: true),
                    TimeSlot = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupID);
                    table.ForeignKey(
                        name: "FK_Groups_AvailableTimes_TimeSlot",
                        column: x => x.TimeSlot,
                        principalTable: "AvailableTimes",
                        principalColumn: "TimeSlot",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Groups_GroupInfo_groupinfoGroupID",
                        column: x => x.groupinfoGroupID,
                        principalTable: "GroupInfo",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_TimeSlot",
                table: "Groups",
                column: "TimeSlot");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_groupinfoGroupID",
                table: "Groups",
                column: "groupinfoGroupID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "AvailableTimes");

            migrationBuilder.DropTable(
                name: "GroupInfo");
        }
    }
}
