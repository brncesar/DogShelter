using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogShelter.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T02_Breed",
                columns: table => new
                {
                    T02_id_Breed = table.Column<Guid>(type: "TEXT", nullable: false),
                    id_BreedIdOnDogApi = table.Column<int>(type: "INTEGER", nullable: false),
                    na_Breed = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    tx_BredFor = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    tx_BredGroup = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    tx_LifeSpan = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    tx_Temperament = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    nu_HeightAverageMetric = table.Column<int>(type: "INTEGER", nullable: false),
                    nu_HeightAverageImperial = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T02_Breed", x => x.T02_id_Breed);
                });

            migrationBuilder.CreateTable(
                name: "T01_Dog",
                columns: table => new
                {
                    T01_id_Dog = table.Column<Guid>(type: "TEXT", nullable: false),
                    na_Dog = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    T02_id_Breed = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T01_Dog", x => x.T01_id_Dog);
                    table.ForeignKey(
                        name: "FK_T01_Dog_T02_Breed_T02_id_Breed",
                        column: x => x.T02_id_Breed,
                        principalTable: "T02_Breed",
                        principalColumn: "T02_id_Breed",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T01_Dog_na_Dog",
                table: "T01_Dog",
                column: "na_Dog",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T01_Dog_T02_id_Breed",
                table: "T01_Dog",
                column: "T02_id_Breed");

            migrationBuilder.CreateIndex(
                name: "IX_T02_Breed_id_BreedIdOnDogApi",
                table: "T02_Breed",
                column: "id_BreedIdOnDogApi",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T01_Dog");

            migrationBuilder.DropTable(
                name: "T02_Breed");
        }
    }
}
