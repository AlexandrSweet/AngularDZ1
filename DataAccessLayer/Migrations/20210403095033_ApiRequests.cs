using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class ApiRequests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiRequestsLogs",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ResourceName = table.Column<string>(nullable: true),
                    EndpointName = table.Column<string>(nullable: true),
                    RequestTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiRequestsLogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiRequestsLogs");
        }
    }
}
