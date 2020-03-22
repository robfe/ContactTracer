using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactTracerNoAuth.Migrations
{
    public partial class InitSqlServer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Checkins",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VenueId = table.Column<long>(nullable: false),
                    IpAddress = table.Column<string>(maxLength: 39, nullable: true),
                    UserAgent = table.Column<string>(maxLength: 1000, nullable: true),
                    SuppliedName = table.Column<string>(maxLength: 200, nullable: true),
                    SuppliedEmail = table.Column<string>(maxLength: 200, nullable: true),
                    SuppliedPhoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    CheckinAtUtc = table.Column<DateTime>(type: "datetime2(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checkins_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checkins_VenueId",
                table: "Checkins",
                column: "VenueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Checkins");

            migrationBuilder.DropTable(
                name: "Venues");
        }
    }
}
