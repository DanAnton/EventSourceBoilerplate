#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace Beersender.API.Migrations.Read;

public partial class InitialCreated : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            "PackageStatuses",
            table => new
            {
                PackageId = table.Column<Guid>("uniqueidentifier", nullable: false),
                Status = table.Column<string>("nvarchar(max)", nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_PackageStatuses", x => x.PackageId); });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "PackageStatuses");
    }
}