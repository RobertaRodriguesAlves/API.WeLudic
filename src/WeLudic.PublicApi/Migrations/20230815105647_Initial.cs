using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeLudic.PublicApi.Migrations;

public partial class Initial : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterDatabase()
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                Name = table.Column<string>(type: "longtext", unicode: false, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Email = table.Column<string>(type: "longtext", unicode: false, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                HashedPassword = table.Column<string>(type: "longtext", unicode: false, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ConfirmAndAgree = table.Column<bool>(type: "tinyint(1)", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                LastModifiedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                AccessToken = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                RefreshToken = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                GeneratedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                ExpirationAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
            },
            constraints: table => table.PrimaryKey("PK_Users", x => x.Id))
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Patients",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                Name = table.Column<string>(type: "longtext", unicode: false, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Email = table.Column<string>(type: "longtext", unicode: false, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ConfirmAndAgree = table.Column<bool>(type: "tinyint(1)", nullable: false),
                UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                LastModifiedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                AccessToken = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                RefreshToken = table.Column<string>(type: "longtext", unicode: false, nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                GeneratedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                ExpirationAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Patients", x => x.Id);
                table.ForeignKey(
                    name: "FK_Patients_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "RouletteOptions",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Name = table.Column<string>(type: "longtext", unicode: false, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                UserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                LastModifiedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_RouletteOptions", x => x.Id);
                table.ForeignKey(
                    name: "FK_RouletteOptions_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "Id");
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "RouletteSessions",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                PatientId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                RouletteOptionId = table.Column<int>(type: "int", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                LastModifiedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_RouletteSessions", x => x.Id);
                table.ForeignKey(
                    name: "FK_RouletteSessions_Patients_PatientId",
                    column: x => x.PatientId,
                    principalTable: "Patients",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_RouletteSessions_RouletteOptions_RouletteOptionId",
                    column: x => x.RouletteOptionId,
                    principalTable: "RouletteOptions",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_RouletteSessions_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "RouletteSessionOptions",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                RouletteSessionId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                RouletteOptionId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_RouletteSessionOptions", x => x.Id);
                table.ForeignKey(
                    name: "FK_RouletteSessionOptions_RouletteOptions_RouletteOptionId",
                    column: x => x.RouletteOptionId,
                    principalTable: "RouletteOptions",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_RouletteSessionOptions_RouletteSessions_RouletteSessionId",
                    column: x => x.RouletteSessionId,
                    principalTable: "RouletteSessions",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.InsertData(
            table: "RouletteOptions",
            columns: new[] { "Id", "CreatedAt", "IsDeleted", "LastModified", "LastModifiedBy", "Name", "UserId" },
            values: new object[,]
            {
                { 1, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9645), false, null, null, "DESENHAR O QUE QUISER", null },
                { 2, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9648), false, null, null, "DESENHAR O QUE O TERAPEUTA PEDIR", null },
                { 3, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9707), false, null, null, "DESENHAR MEUS SONHOS", null },
                { 4, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9708), false, null, null, "COLORIR MEUS MEDOS", null },
                { 5, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9709), false, null, null, "COLORIR MEUS PESADELOS", null },
                { 6, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9710), false, null, null, "COLORIR UM DESENHO", null },
                { 7, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9711), false, null, null, "INVENTAR UMA HISTÓRIA", null },
                { 8, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9712), false, null, null, "CINETERAPIA", null },
                { 9, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9713), false, null, null, "ATIVIDADE COM A FAMÍLIA TODA", null },
                { 10, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9714), false, null, null, "ATIVIDADE COM O(S) IRMÃO(S)", null },
                { 11, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9714), false, null, null, "ATIVIDADE COM OS PAIS", null },
                { 12, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9715), false, null, null, "ATIVIDADE COM A MÃE", null },
                { 13, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9716), false, null, null, "ATIVIDADE COM O PAI", null },
                { 14, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9717), false, null, null, "ATIVIDADE COM A VOVÓ", null },
                { 15, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9718), false, null, null, "ATIVIDADE COM O VOVÔ", null },
                { 16, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9719), false, null, null, "ATIVIDADE COM UM AMIGO OU AMIGA", null },
                { 17, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9719), false, null, null, "DOBRADURA", null },
                { 18, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9720), false, null, null, "MÍMICA", null },
                { 19, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9721), false, null, null, "JOGO: O MESTRE MANDOU", null },
                { 20, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9722), false, null, null, "ESCUTAR UMA MÚSICA", null },
                { 21, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9723), false, null, null, "BRINCAR DE MEDITAR", null },
                { 22, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9724), false, null, null, "UTILIZAR BRINQUEDOS ESPECIAIS", null },
                { 23, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9725), false, null, null, "CONTAR PIADAS", null },
                { 24, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9725), false, null, null, "CONTAR CHARADAS", null },
                { 25, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9726), false, null, null, "JOGO: O QUE É O QUE É", null },
                { 26, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9727), false, null, null, "LER UMA HISTÓRIA", null },
                { 27, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9728), false, null, null, "OUVIR UMA HISTÓRIA", null },
                { 28, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9729), false, null, null, "ESCREVER UMA HISTÓRIA", null },
                { 29, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9730), false, null, null, "USAR CAIXA DE ARTES", null },
                { 30, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9731), false, null, null, "BRINCAR DE ADIVINHE O DESENHO", null },
                { 31, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9732), false, null, null, "JOGO: MEMÓRIA & ANIMAIS", null },
                { 32, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9733), false, null, null, "JOGO: PRECISO DE AJUDA", null },
                { 33, new DateTime(2023, 8, 15, 10, 56, 46, 790, DateTimeKind.Utc).AddTicks(9733), false, null, null, "JOGO: GOSTO / NÃO GOSTO", null }
            });

        migrationBuilder.CreateIndex(
            name: "IX_Patients_UserId",
            table: "Patients",
            column: "UserId");

        migrationBuilder.CreateIndex(
            name: "IX_RouletteOptions_UserId",
            table: "RouletteOptions",
            column: "UserId");

        migrationBuilder.CreateIndex(
            name: "IX_RouletteSessionOptions_RouletteOptionId",
            table: "RouletteSessionOptions",
            column: "RouletteOptionId");

        migrationBuilder.CreateIndex(
            name: "IX_RouletteSessionOptions_RouletteSessionId",
            table: "RouletteSessionOptions",
            column: "RouletteSessionId");

        migrationBuilder.CreateIndex(
            name: "IX_RouletteSessions_PatientId",
            table: "RouletteSessions",
            column: "PatientId");

        migrationBuilder.CreateIndex(
            name: "IX_RouletteSessions_RouletteOptionId",
            table: "RouletteSessions",
            column: "RouletteOptionId");

        migrationBuilder.CreateIndex(
            name: "IX_RouletteSessions_UserId",
            table: "RouletteSessions",
            column: "UserId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "RouletteSessionOptions");

        migrationBuilder.DropTable(
            name: "RouletteSessions");

        migrationBuilder.DropTable(
            name: "Patients");

        migrationBuilder.DropTable(
            name: "RouletteOptions");

        migrationBuilder.DropTable(
            name: "Users");
    }
}
