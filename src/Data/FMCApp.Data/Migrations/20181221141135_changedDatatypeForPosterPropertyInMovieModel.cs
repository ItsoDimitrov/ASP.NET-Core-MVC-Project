using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FMCApp.Data.Migrations
{
    public partial class changedDatatypeForPosterPropertyInMovieModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoviePoster",
                table: "Movies");

            migrationBuilder.AddColumn<string>(
                name: "MoviePosterUrl",
                table: "Movies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoviePosterUrl",
                table: "Movies");

            migrationBuilder.AddColumn<byte[]>(
                name: "MoviePoster",
                table: "Movies",
                nullable: true);
        }
    }
}
