using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcertAfisha.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ConcertFinish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConcertEntities_LocationEntities_LocationId",
                table: "ConcertEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokenEntities_UserEntities_UserId",
                table: "RefreshTokenEntities");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "LocationEntities");

            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "LocationEntities",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Lng",
                table: "LocationEntities",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_ConcertEntities_LocationEntities_LocationId",
                table: "ConcertEntities",
                column: "LocationId",
                principalTable: "LocationEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokenEntities_UserEntities_UserId",
                table: "RefreshTokenEntities",
                column: "UserId",
                principalTable: "UserEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConcertEntities_LocationEntities_LocationId",
                table: "ConcertEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokenEntities_UserEntities_UserId",
                table: "RefreshTokenEntities");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "LocationEntities");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "LocationEntities");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "LocationEntities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ConcertEntities_LocationEntities_LocationId",
                table: "ConcertEntities",
                column: "LocationId",
                principalTable: "LocationEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokenEntities_UserEntities_UserId",
                table: "RefreshTokenEntities",
                column: "UserId",
                principalTable: "UserEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
