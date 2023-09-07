using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeLudic.PublicApi.Migrations;

public partial class AtualizaçãotabelaRouletteSession : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "PatientId",
            table: "RouletteSessions");

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
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<Guid>(
            name: "PatientId",
            table: "RouletteSessions",
            type: "char(36)",
            nullable: false,
            defaultValue: Guid.Empty,
            collation: "ascii_general_ci");

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
}
