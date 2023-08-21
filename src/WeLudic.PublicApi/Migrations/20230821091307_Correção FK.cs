using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeLudic.PublicApi.Migrations
{
    public partial class CorreçãoFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RouletteSessions_RouletteOptions_RouletteOptionId",
                table: "RouletteSessions");

            migrationBuilder.DropIndex(
                name: "IX_RouletteSessions_RouletteOptionId",
                table: "RouletteSessions");

            migrationBuilder.DropColumn(
                name: "RouletteOptionId",
                table: "RouletteSessions");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RouletteOptionId",
                table: "RouletteSessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6275));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6279));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6280));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6280));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6281));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6290));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6291));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6291));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6292));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6293));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6294));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6295));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6295));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6296));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6297));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6298));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6298));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6299));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6300));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6301));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6302));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6302));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6303));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6304));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6305));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6305));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6306));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6307));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6308));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6309));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6309));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6310));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 11, 1, 28, 469, DateTimeKind.Utc).AddTicks(6311));

            migrationBuilder.CreateIndex(
                name: "IX_RouletteSessions_RouletteOptionId",
                table: "RouletteSessions",
                column: "RouletteOptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_RouletteSessions_RouletteOptions_RouletteOptionId",
                table: "RouletteSessions",
                column: "RouletteOptionId",
                principalTable: "RouletteOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
