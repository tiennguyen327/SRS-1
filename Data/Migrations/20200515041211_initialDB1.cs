using Microsoft.EntityFrameworkCore.Migrations;

namespace SRS.Data.Migrations
{
    public partial class initialDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkOrder",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    MostRecentNote = table.Column<string>(nullable: true),
                    RequestStatus = table.Column<string>(nullable: true),
                    WONumber = table.Column<string>(nullable: true),
                    Workflow = table.Column<string>(nullable: true),
                    WOTitle = table.Column<string>(nullable: true),
                    ClientWorkRequestIDPrefix = table.Column<string>(nullable: true),
                    ClientWorkRequestIDNumber = table.Column<string>(nullable: true),
                    ZurichSubProjectCode = table.Column<string>(nullable: true),
                    BusinessUnitID = table.Column<string>(nullable: true),
                    ClientWorkRequestID = table.Column<string>(nullable: true),
                    RelatedWorkOrderRequests = table.Column<string>(nullable: true),
                    GAMSRNumber = table.Column<string>(nullable: true),
                    GAMSRNumberLink = table.Column<string>(nullable: true),
                    ClientSAPID = table.Column<string>(nullable: true),
                    ClientStrategicProgramID = table.Column<string>(nullable: true),
                    ClientProgramID = table.Column<string>(nullable: true),
                    ClientProjectID = table.Column<string>(nullable: true),
                    ClientStrategicProjectID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrder", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkOrder");
        }
    }
}
