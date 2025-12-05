using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U5_W1_D5poliziaMunicipale.Migrations
{
    /// <inheritdoc />
    public partial class MuleDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Violazioni",
                columns: table => new
                {
                    ViolazioneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DescrizioneViolazione = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Violazioni", x => x.ViolazioneId);
                });

            migrationBuilder.CreateTable(
                name: "Verbali",
                columns: table => new
                {
                    VerbaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NominativoAgente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataViolazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataTrascrizione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IndirizzoViolazione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImportoMulta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DecurtazionePunti = table.Column<int>(type: "int", nullable: false),
                    ViolazioneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verbali", x => x.VerbaleId);
                    table.ForeignKey(
                        name: "FK_Verbali_Violazioni_ViolazioneId",
                        column: x => x.ViolazioneId,
                        principalTable: "Violazioni",
                        principalColumn: "ViolazioneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Anagrafiche",
                columns: table => new
                {
                    AnagraficaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodiceFiscale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Citta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cap = table.Column<int>(type: "int", nullable: false),
                    VerbaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anagrafiche", x => x.AnagraficaId);
                    table.ForeignKey(
                        name: "FK_Anagrafiche_Verbali_VerbaleId",
                        column: x => x.VerbaleId,
                        principalTable: "Verbali",
                        principalColumn: "VerbaleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anagrafiche_VerbaleId",
                table: "Anagrafiche",
                column: "VerbaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Verbali_ViolazioneId",
                table: "Verbali",
                column: "ViolazioneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anagrafiche");

            migrationBuilder.DropTable(
                name: "Verbali");

            migrationBuilder.DropTable(
                name: "Violazioni");
        }
    }
}
