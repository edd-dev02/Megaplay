using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_megaplay.Migrations
{
    /// <inheritdoc />
    public partial class CreatedSectionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_SectionId",
                table: "Movies",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Sections_SectionId",
                table: "Movies",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Sections_SectionId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Movies_SectionId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Movies");
        }
    }
}
