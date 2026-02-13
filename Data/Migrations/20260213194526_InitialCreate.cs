using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightBase.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IcaoAirlineCode = table.Column<string>(type: "TEXT", maxLength: 4, nullable: false),
                    IataAirlineCode = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false),
                    IcaoAircraftType = table.Column<string>(type: "TEXT", maxLength: 4, nullable: false),
                    FlightNumber = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    OriginIcao = table.Column<string>(type: "TEXT", maxLength: 4, nullable: false),
                    OriginIata = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false),
                    DestinationIcao = table.Column<string>(type: "TEXT", maxLength: 4, nullable: false),
                    DestinationIata = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false),
                    Duration = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    IsCurrentlyOperated = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_DestinationIcao",
                table: "Flights",
                column: "DestinationIcao");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_IcaoAirlineCode_FlightNumber",
                table: "Flights",
                columns: new[] { "IcaoAirlineCode", "FlightNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_IsCurrentlyOperated",
                table: "Flights",
                column: "IsCurrentlyOperated");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_OriginIcao",
                table: "Flights",
                column: "OriginIcao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
