using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeLudic.PublicApi.Migrations
{
    public partial class RemoçãoPatientFKRouletteSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RouletteSessions_Patients_PatientId",
                table: "RouletteSessions");

            migrationBuilder.DropIndex(
                name: "IX_RouletteSessions_PatientId",
                table: "RouletteSessions");

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5623));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5627));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5628));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5629));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5630));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5631));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5632));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5633));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5634));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5635));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5636));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5637));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5649));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5650));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5651));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5652));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5653));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5654));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5655));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5656));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5657));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5658));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5660));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5661));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5662));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5663));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5664));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5665));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5666));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5667));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5668));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 9, 23, 52, 302, DateTimeKind.Utc).AddTicks(5669));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9645));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9648));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9707));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9708));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9709));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9710));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9711));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9712));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9713));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9714));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9714));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9715));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9716));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9717));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9718));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9719));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9719));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9720));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9721));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9722));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9723));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9724));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9725));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9725));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9726));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9727));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9728));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9729));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9730));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9731));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9732));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9733));

            migrationBuilder.UpdateData(
                table: "RouletteOptions",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9733));

            migrationBuilder.CreateIndex(
                name: "IX_RouletteSessions_PatientId",
                table: "RouletteSessions",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_RouletteSessions_Patients_PatientId",
                table: "RouletteSessions",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
