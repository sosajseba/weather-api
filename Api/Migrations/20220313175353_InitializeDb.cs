using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class InitializeDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Condition = table.Column<int>(type: "int", nullable: false),
                    TempC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TempF = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Humidity = table.Column<byte>(type: "tinyint", nullable: false),
                    Wind = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RainChance = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weather_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Argentina" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Brasil" });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Ciudad Autónoma de Buenos Aires" },
                    { 2, 1, "Buenos Aires" },
                    { 3, 2, "Río de Janeiro" },
                    { 4, 2, "São Paulo" }
                });

            migrationBuilder.InsertData(
                table: "Weather",
                columns: new[] { "Id", "CityId", "Condition", "Date", "Humidity", "RainChance", "TempC", "TempF", "Wind" },
                values: new object[,]
                {
                    { 5, 1, 2, new DateTime(2022, 3, 13, 0, 0, 0, 0, DateTimeKind.Local), (byte)78, (byte)32, 19.4m, 51.4m, 17.9m },
                    { 6, 1, 0, new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Local), (byte)88, (byte)34, 34.3m, 66.3m, 16.8m },
                    { 7, 1, 3, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Local), (byte)50, (byte)32, 3.3m, 35.3m, 17.4m },
                    { 8, 1, 0, new DateTime(2022, 3, 16, 0, 0, 0, 0, DateTimeKind.Local), (byte)92, (byte)84, 30.5m, 62.5m, 3.2m },
                    { 9, 1, 3, new DateTime(2022, 3, 17, 0, 0, 0, 0, DateTimeKind.Local), (byte)13, (byte)98, -1.1m, 30.9m, 1.4m },
                    { 10, 1, 2, new DateTime(2022, 3, 18, 0, 0, 0, 0, DateTimeKind.Local), (byte)60, (byte)52, 49.7m, 81.7m, 19.7m },
                    { 11, 1, 4, new DateTime(2022, 3, 19, 0, 0, 0, 0, DateTimeKind.Local), (byte)64, (byte)7, 45.0m, 77.0m, 8.5m },
                    { 12, 1, 1, new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Local), (byte)8, (byte)63, -31.3m, 0.7m, 12.1m },
                    { 13, 1, 1, new DateTime(2022, 3, 21, 0, 0, 0, 0, DateTimeKind.Local), (byte)60, (byte)80, 12.9m, 44.9m, 0.8m },
                    { 14, 1, 2, new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), (byte)15, (byte)55, -10.0m, 22.0m, 0.3m },
                    { 15, 1, 3, new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), (byte)78, (byte)16, 7.4m, 39.4m, 11.1m },
                    { 16, 1, 3, new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), (byte)69, (byte)79, -17.0m, 15.0m, 6.2m },
                    { 17, 1, 0, new DateTime(2022, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), (byte)85, (byte)54, -45.4m, -13.4m, 6.0m },
                    { 18, 1, 1, new DateTime(2022, 3, 26, 0, 0, 0, 0, DateTimeKind.Local), (byte)6, (byte)4, -3.2m, 28.8m, 3.1m },
                    { 19, 1, 1, new DateTime(2022, 3, 27, 0, 0, 0, 0, DateTimeKind.Local), (byte)83, (byte)77, 44.3m, 76.3m, 17.8m },
                    { 20, 1, 2, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Local), (byte)11, (byte)50, 41.6m, 73.6m, 3.5m },
                    { 21, 1, 3, new DateTime(2022, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), (byte)35, (byte)20, -47.5m, -15.5m, 5.4m },
                    { 22, 1, 4, new DateTime(2022, 3, 30, 0, 0, 0, 0, DateTimeKind.Local), (byte)56, (byte)88, 5.7m, 37.7m, 3.4m },
                    { 23, 1, 1, new DateTime(2022, 3, 31, 0, 0, 0, 0, DateTimeKind.Local), (byte)33, (byte)38, 21.6m, 53.6m, 12.5m },
                    { 24, 1, 1, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Local), (byte)40, (byte)51, 32.3m, 64.3m, 5.0m },
                    { 25, 1, 4, new DateTime(2022, 4, 2, 0, 0, 0, 0, DateTimeKind.Local), (byte)12, (byte)11, 2.0m, 34.0m, 14.6m },
                    { 26, 1, 3, new DateTime(2022, 4, 3, 0, 0, 0, 0, DateTimeKind.Local), (byte)70, (byte)2, -18.6m, 13.4m, 13.3m },
                    { 27, 1, 1, new DateTime(2022, 4, 4, 0, 0, 0, 0, DateTimeKind.Local), (byte)53, (byte)22, 46.2m, 78.2m, 8.1m },
                    { 28, 1, 5, new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Local), (byte)80, (byte)97, 31.5m, 63.5m, 4.9m },
                    { 29, 1, 5, new DateTime(2022, 4, 6, 0, 0, 0, 0, DateTimeKind.Local), (byte)25, (byte)93, -13.6m, 18.4m, 11.1m },
                    { 30, 1, 0, new DateTime(2022, 4, 7, 0, 0, 0, 0, DateTimeKind.Local), (byte)97, (byte)69, 42.2m, 74.2m, 10.6m },
                    { 31, 1, 5, new DateTime(2022, 4, 8, 0, 0, 0, 0, DateTimeKind.Local), (byte)54, (byte)38, -34.2m, -2.2m, 17.6m },
                    { 32, 1, 4, new DateTime(2022, 4, 9, 0, 0, 0, 0, DateTimeKind.Local), (byte)2, (byte)77, 21.3m, 53.3m, 8.2m },
                    { 33, 1, 3, new DateTime(2022, 4, 10, 0, 0, 0, 0, DateTimeKind.Local), (byte)89, (byte)40, 39.5m, 71.5m, 1.2m },
                    { 34, 1, 4, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), (byte)47, (byte)69, 10.6m, 42.6m, 16.5m },
                    { 35, 2, 3, new DateTime(2022, 3, 13, 0, 0, 0, 0, DateTimeKind.Local), (byte)41, (byte)47, 49.1m, 81.1m, 11.1m },
                    { 36, 2, 4, new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Local), (byte)62, (byte)98, 32.5m, 64.5m, 8.4m },
                    { 37, 2, 2, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Local), (byte)50, (byte)68, 32.7m, 64.7m, 3.0m },
                    { 38, 2, 3, new DateTime(2022, 3, 16, 0, 0, 0, 0, DateTimeKind.Local), (byte)19, (byte)3, 30.4m, 62.4m, 0.2m },
                    { 39, 2, 5, new DateTime(2022, 3, 17, 0, 0, 0, 0, DateTimeKind.Local), (byte)5, (byte)61, -7.0m, 25.0m, 9.8m },
                    { 40, 2, 0, new DateTime(2022, 3, 18, 0, 0, 0, 0, DateTimeKind.Local), (byte)63, (byte)55, -34.9m, -2.9m, 7.6m },
                    { 41, 2, 4, new DateTime(2022, 3, 19, 0, 0, 0, 0, DateTimeKind.Local), (byte)47, (byte)41, 9.9m, 41.9m, 13.0m },
                    { 42, 2, 1, new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Local), (byte)13, (byte)35, -11.0m, 21.0m, 1.8m },
                    { 43, 2, 1, new DateTime(2022, 3, 21, 0, 0, 0, 0, DateTimeKind.Local), (byte)51, (byte)25, 34.9m, 66.9m, 4.9m },
                    { 44, 2, 2, new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), (byte)33, (byte)75, 6.9m, 38.9m, 5.6m },
                    { 45, 2, 2, new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), (byte)10, (byte)79, 41.3m, 73.3m, 14.1m },
                    { 46, 2, 0, new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), (byte)86, (byte)65, -38.8m, -6.8m, 2.6m }
                });

            migrationBuilder.InsertData(
                table: "Weather",
                columns: new[] { "Id", "CityId", "Condition", "Date", "Humidity", "RainChance", "TempC", "TempF", "Wind" },
                values: new object[,]
                {
                    { 47, 2, 4, new DateTime(2022, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), (byte)91, (byte)66, 45.8m, 77.8m, 11.2m },
                    { 48, 2, 1, new DateTime(2022, 3, 26, 0, 0, 0, 0, DateTimeKind.Local), (byte)31, (byte)62, 1.4m, 33.4m, 0.6m },
                    { 49, 2, 4, new DateTime(2022, 3, 27, 0, 0, 0, 0, DateTimeKind.Local), (byte)53, (byte)34, 9.3m, 41.3m, 9.1m },
                    { 50, 2, 4, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Local), (byte)47, (byte)80, -28.9m, 3.1m, 8.9m },
                    { 51, 2, 2, new DateTime(2022, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), (byte)47, (byte)34, -3.8m, 28.2m, 12.9m },
                    { 52, 2, 3, new DateTime(2022, 3, 30, 0, 0, 0, 0, DateTimeKind.Local), (byte)11, (byte)35, -32.4m, -0.4m, 14.1m },
                    { 53, 2, 0, new DateTime(2022, 3, 31, 0, 0, 0, 0, DateTimeKind.Local), (byte)59, (byte)57, -25.8m, 6.2m, 4.9m },
                    { 54, 2, 4, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Local), (byte)7, (byte)35, 45.1m, 77.1m, 15.8m },
                    { 55, 2, 0, new DateTime(2022, 4, 2, 0, 0, 0, 0, DateTimeKind.Local), (byte)73, (byte)83, 10.4m, 42.4m, 0.9m },
                    { 56, 2, 3, new DateTime(2022, 4, 3, 0, 0, 0, 0, DateTimeKind.Local), (byte)85, (byte)2, 9.4m, 41.4m, 18.6m },
                    { 57, 2, 4, new DateTime(2022, 4, 4, 0, 0, 0, 0, DateTimeKind.Local), (byte)16, (byte)1, 5.7m, 37.7m, 16.5m },
                    { 58, 2, 4, new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Local), (byte)99, (byte)50, 17.2m, 49.2m, 12.9m },
                    { 59, 2, 0, new DateTime(2022, 4, 6, 0, 0, 0, 0, DateTimeKind.Local), (byte)9, (byte)70, -24.7m, 7.3m, 10.4m },
                    { 60, 2, 3, new DateTime(2022, 4, 7, 0, 0, 0, 0, DateTimeKind.Local), (byte)82, (byte)18, -34.4m, -2.4m, 19.8m },
                    { 61, 2, 4, new DateTime(2022, 4, 8, 0, 0, 0, 0, DateTimeKind.Local), (byte)26, (byte)31, 4.4m, 36.4m, 10.3m },
                    { 62, 2, 1, new DateTime(2022, 4, 9, 0, 0, 0, 0, DateTimeKind.Local), (byte)16, (byte)51, -39.0m, -7.0m, 5.2m },
                    { 63, 2, 1, new DateTime(2022, 4, 10, 0, 0, 0, 0, DateTimeKind.Local), (byte)32, (byte)12, -17.9m, 14.1m, 7.7m },
                    { 64, 2, 5, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), (byte)51, (byte)50, 44.1m, 76.1m, 1.8m },
                    { 65, 3, 5, new DateTime(2022, 3, 13, 0, 0, 0, 0, DateTimeKind.Local), (byte)18, (byte)39, -21.4m, 10.6m, 19.9m },
                    { 66, 3, 0, new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Local), (byte)47, (byte)86, 22.3m, 54.3m, 19.9m },
                    { 67, 3, 1, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Local), (byte)26, (byte)37, -25.1m, 6.9m, 10.6m },
                    { 68, 3, 4, new DateTime(2022, 3, 16, 0, 0, 0, 0, DateTimeKind.Local), (byte)79, (byte)75, 43.2m, 75.2m, 3.3m },
                    { 69, 3, 4, new DateTime(2022, 3, 17, 0, 0, 0, 0, DateTimeKind.Local), (byte)62, (byte)18, -32.8m, -0.8m, 15.2m },
                    { 70, 3, 1, new DateTime(2022, 3, 18, 0, 0, 0, 0, DateTimeKind.Local), (byte)26, (byte)38, 40.4m, 72.4m, 5.7m },
                    { 71, 3, 5, new DateTime(2022, 3, 19, 0, 0, 0, 0, DateTimeKind.Local), (byte)75, (byte)4, 25.9m, 57.9m, 10.9m },
                    { 72, 3, 1, new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Local), (byte)6, (byte)82, 26.0m, 58.0m, 17.5m },
                    { 73, 3, 1, new DateTime(2022, 3, 21, 0, 0, 0, 0, DateTimeKind.Local), (byte)47, (byte)2, 24.8m, 56.8m, 10.5m },
                    { 74, 3, 3, new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), (byte)99, (byte)23, 10.5m, 42.5m, 0.1m },
                    { 75, 3, 5, new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), (byte)80, (byte)3, 44.0m, 76.0m, 6.1m },
                    { 76, 3, 3, new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), (byte)21, (byte)18, 0.3m, 32.3m, 1.2m },
                    { 77, 3, 1, new DateTime(2022, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), (byte)12, (byte)32, 35.6m, 67.6m, 3.9m },
                    { 78, 3, 2, new DateTime(2022, 3, 26, 0, 0, 0, 0, DateTimeKind.Local), (byte)5, (byte)69, -42.1m, -10.1m, 7.7m },
                    { 79, 3, 1, new DateTime(2022, 3, 27, 0, 0, 0, 0, DateTimeKind.Local), (byte)62, (byte)7, -30.5m, 1.5m, 4.1m },
                    { 80, 3, 1, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Local), (byte)38, (byte)28, 8.2m, 40.2m, 1.3m },
                    { 81, 3, 3, new DateTime(2022, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), (byte)63, (byte)47, 46.1m, 78.1m, 4.7m },
                    { 82, 3, 3, new DateTime(2022, 3, 30, 0, 0, 0, 0, DateTimeKind.Local), (byte)20, (byte)29, 23.9m, 55.9m, 19.9m },
                    { 83, 3, 1, new DateTime(2022, 3, 31, 0, 0, 0, 0, DateTimeKind.Local), (byte)96, (byte)3, -44.8m, -12.8m, 7.6m },
                    { 84, 3, 1, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Local), (byte)56, (byte)55, -33.0m, -1.0m, 17.2m },
                    { 85, 3, 3, new DateTime(2022, 4, 2, 0, 0, 0, 0, DateTimeKind.Local), (byte)7, (byte)0, -4.9m, 27.1m, 15.7m },
                    { 86, 3, 5, new DateTime(2022, 4, 3, 0, 0, 0, 0, DateTimeKind.Local), (byte)2, (byte)1, -25.2m, 6.8m, 14.2m },
                    { 87, 3, 3, new DateTime(2022, 4, 4, 0, 0, 0, 0, DateTimeKind.Local), (byte)80, (byte)71, 33.1m, 65.1m, 9.5m },
                    { 88, 3, 0, new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Local), (byte)89, (byte)90, 50.0m, 82.0m, 11.2m }
                });

            migrationBuilder.InsertData(
                table: "Weather",
                columns: new[] { "Id", "CityId", "Condition", "Date", "Humidity", "RainChance", "TempC", "TempF", "Wind" },
                values: new object[,]
                {
                    { 89, 3, 2, new DateTime(2022, 4, 6, 0, 0, 0, 0, DateTimeKind.Local), (byte)22, (byte)57, 31.5m, 63.5m, 16.4m },
                    { 90, 3, 0, new DateTime(2022, 4, 7, 0, 0, 0, 0, DateTimeKind.Local), (byte)39, (byte)98, 35.2m, 67.2m, 17.4m },
                    { 91, 3, 2, new DateTime(2022, 4, 8, 0, 0, 0, 0, DateTimeKind.Local), (byte)72, (byte)86, 28.3m, 60.3m, 4.2m },
                    { 92, 3, 3, new DateTime(2022, 4, 9, 0, 0, 0, 0, DateTimeKind.Local), (byte)87, (byte)36, 6.0m, 38.0m, 19.6m },
                    { 93, 3, 5, new DateTime(2022, 4, 10, 0, 0, 0, 0, DateTimeKind.Local), (byte)11, (byte)7, -38.9m, -6.9m, 13.6m },
                    { 94, 3, 5, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), (byte)35, (byte)42, -40.9m, -8.9m, 9.0m },
                    { 95, 4, 3, new DateTime(2022, 3, 13, 0, 0, 0, 0, DateTimeKind.Local), (byte)3, (byte)49, 49.6m, 81.6m, 0.0m },
                    { 96, 4, 4, new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Local), (byte)11, (byte)71, -29.8m, 2.2m, 18.5m },
                    { 97, 4, 4, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Local), (byte)63, (byte)77, -15.4m, 16.6m, 9.8m },
                    { 98, 4, 0, new DateTime(2022, 3, 16, 0, 0, 0, 0, DateTimeKind.Local), (byte)55, (byte)81, 4.7m, 36.7m, 2.1m },
                    { 99, 4, 5, new DateTime(2022, 3, 17, 0, 0, 0, 0, DateTimeKind.Local), (byte)56, (byte)32, 41.1m, 73.1m, 6.7m },
                    { 100, 4, 2, new DateTime(2022, 3, 18, 0, 0, 0, 0, DateTimeKind.Local), (byte)66, (byte)90, -16.5m, 15.5m, 14.1m },
                    { 101, 4, 3, new DateTime(2022, 3, 19, 0, 0, 0, 0, DateTimeKind.Local), (byte)6, (byte)70, -15.7m, 16.3m, 0.7m },
                    { 102, 4, 5, new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Local), (byte)98, (byte)64, -2.7m, 29.3m, 15.0m },
                    { 103, 4, 5, new DateTime(2022, 3, 21, 0, 0, 0, 0, DateTimeKind.Local), (byte)6, (byte)71, -7.0m, 25.0m, 6.1m },
                    { 104, 4, 4, new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), (byte)96, (byte)97, -28.4m, 3.6m, 3.0m },
                    { 105, 4, 3, new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), (byte)30, (byte)71, 3.1m, 35.1m, 0.7m },
                    { 106, 4, 5, new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), (byte)41, (byte)41, -35.0m, -3.0m, 9.7m },
                    { 107, 4, 2, new DateTime(2022, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), (byte)2, (byte)93, -33.5m, -1.5m, 11.3m },
                    { 108, 4, 4, new DateTime(2022, 3, 26, 0, 0, 0, 0, DateTimeKind.Local), (byte)48, (byte)65, 9.2m, 41.2m, 1.8m },
                    { 109, 4, 1, new DateTime(2022, 3, 27, 0, 0, 0, 0, DateTimeKind.Local), (byte)81, (byte)93, 0.3m, 32.3m, 4.3m },
                    { 110, 4, 4, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Local), (byte)49, (byte)6, 12.3m, 44.3m, 6.2m },
                    { 111, 4, 0, new DateTime(2022, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), (byte)4, (byte)63, -38.8m, -6.8m, 2.6m },
                    { 112, 4, 3, new DateTime(2022, 3, 30, 0, 0, 0, 0, DateTimeKind.Local), (byte)22, (byte)55, -18.1m, 13.9m, 6.0m },
                    { 113, 4, 0, new DateTime(2022, 3, 31, 0, 0, 0, 0, DateTimeKind.Local), (byte)84, (byte)3, 7.5m, 39.5m, 14.3m },
                    { 114, 4, 4, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Local), (byte)1, (byte)23, 21.4m, 53.4m, 4.0m },
                    { 115, 4, 2, new DateTime(2022, 4, 2, 0, 0, 0, 0, DateTimeKind.Local), (byte)6, (byte)63, -40.5m, -8.5m, 19.0m },
                    { 116, 4, 3, new DateTime(2022, 4, 3, 0, 0, 0, 0, DateTimeKind.Local), (byte)48, (byte)58, 1.6m, 33.6m, 12.8m },
                    { 117, 4, 4, new DateTime(2022, 4, 4, 0, 0, 0, 0, DateTimeKind.Local), (byte)12, (byte)84, -43.6m, -11.6m, 14.8m },
                    { 118, 4, 3, new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Local), (byte)90, (byte)42, 13.6m, 45.6m, 2.6m },
                    { 119, 4, 1, new DateTime(2022, 4, 6, 0, 0, 0, 0, DateTimeKind.Local), (byte)27, (byte)62, -49.2m, -17.2m, 10.4m },
                    { 120, 4, 3, new DateTime(2022, 4, 7, 0, 0, 0, 0, DateTimeKind.Local), (byte)23, (byte)91, 44.3m, 76.3m, 0.6m },
                    { 121, 4, 4, new DateTime(2022, 4, 8, 0, 0, 0, 0, DateTimeKind.Local), (byte)51, (byte)9, 28.8m, 60.8m, 7.3m },
                    { 122, 4, 0, new DateTime(2022, 4, 9, 0, 0, 0, 0, DateTimeKind.Local), (byte)74, (byte)95, 20.8m, 52.8m, 8.0m },
                    { 123, 4, 4, new DateTime(2022, 4, 10, 0, 0, 0, 0, DateTimeKind.Local), (byte)97, (byte)0, -33.5m, -1.5m, 9.6m },
                    { 124, 4, 0, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), (byte)4, (byte)88, -12.8m, 19.2m, 7.0m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                table: "City",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Weather_CityId",
                table: "Weather",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weather");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
