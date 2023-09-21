using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeLudic.PublicApi.Migrations
{
    public partial class AltertablePatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Users_UserId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Patients",
                newName: "RouletteSessionId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_UserId",
                table: "Patients",
                newName: "IX_Patients_RouletteSessionId");

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3842));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3844));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3845));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3845));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3846));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3847));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3848));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3848));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3849));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3850));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3851));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3851));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3852));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3853));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3853));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3854));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3855));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3855));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3856));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3857));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3857));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3859));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3859));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3860));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3860));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3861));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3862));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3862));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3863));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3864));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3864));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 14, 9, 54, 36, 819, DateTimeKind.Utc).AddTicks(3865));

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_RouletteSessions_RouletteSessionId",
                table: "Patients",
                column: "RouletteSessionId",
                principalTable: "RouletteSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_RouletteSessions_RouletteSessionId",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "RouletteSessionId",
                table: "Patients",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_RouletteSessionId",
                table: "Patients",
                newName: "IX_Patients_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Patients",
                type: "longtext",
                unicode: false,
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4292));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4298));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4298));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4299));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4300));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4301));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4301));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4302));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4303));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4304));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4304));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4305));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4306));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4307));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4307));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4308));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4309));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4309));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4310));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4311));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4311));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4312));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4314));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4315));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4315));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4316));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4317));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4317));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4318));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4319));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 21, 9, 13, 7, 491, DateTimeKind.Utc).AddTicks(4319));

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Users_UserId",
                table: "Patients",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
