using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Whatch.Migrations
{
    public partial class cleanupstructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Whatchlists");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Whatchlists");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "Whatchlists");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Whatchlists");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "Whatchlists");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "FilmReviews");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "FilmReviews");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "FilmReviews");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "FilmReviews");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "FilmReviews");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "FilmCasts");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "FilmCasts");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "FilmCasts");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "FilmCasts");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "FilmCasts");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "FilmCasts");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "Actors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Whatchlists",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "Whatchlists",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "Whatchlists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Whatchlists",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "Whatchlists",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Films",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Films",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "Films",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "Films",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Films",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "Films",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "FilmReviews",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "FilmReviews",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "FilmReviews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "FilmReviews",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "FilmReviews",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "FilmCasts",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "FilmCasts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "FilmCasts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "FilmCasts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "FilmCasts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "FilmCasts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Actors",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Actors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "Actors",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Actors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "Actors",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
