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
                    { 5, 1, 3, new DateTime(2022, 3, 16, 0, 0, 0, 0, DateTimeKind.Local), (byte)41, (byte)2, 32.9m, 91.3m, 17.5m },
                    { 6, 1, 5, new DateTime(2022, 3, 17, 0, 0, 0, 0, DateTimeKind.Local), (byte)68, (byte)12, -15.2m, 4.6m, 19.9m },
                    { 7, 1, 2, new DateTime(2022, 3, 18, 0, 0, 0, 0, DateTimeKind.Local), (byte)62, (byte)23, -36.8m, -34.2m, 14.4m },
                    { 8, 1, 4, new DateTime(2022, 3, 19, 0, 0, 0, 0, DateTimeKind.Local), (byte)87, (byte)24, -34.8m, -30.6m, 0.5m },
                    { 9, 1, 1, new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Local), (byte)59, (byte)86, -21.3m, -6.4m, 19.1m },
                    { 10, 1, 3, new DateTime(2022, 3, 21, 0, 0, 0, 0, DateTimeKind.Local), (byte)8, (byte)44, -19.8m, -3.7m, 9.9m },
                    { 11, 1, 4, new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), (byte)47, (byte)19, -21.8m, -7.2m, 2.4m },
                    { 12, 1, 2, new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), (byte)18, (byte)15, 5.9m, 42.7m, 12.7m },
                    { 13, 1, 3, new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), (byte)29, (byte)72, -44.2m, -47.6m, 3.1m },
                    { 14, 1, 2, new DateTime(2022, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), (byte)70, (byte)19, 10.7m, 51.3m, 11.3m },
                    { 15, 1, 5, new DateTime(2022, 3, 26, 0, 0, 0, 0, DateTimeKind.Local), (byte)38, (byte)12, 27.8m, 82.1m, 3.5m },
                    { 16, 1, 3, new DateTime(2022, 3, 27, 0, 0, 0, 0, DateTimeKind.Local), (byte)82, (byte)11, 45.8m, 114.4m, 8.3m },
                    { 17, 1, 0, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Local), (byte)49, (byte)95, 8.5m, 47.4m, 13.5m },
                    { 18, 1, 3, new DateTime(2022, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), (byte)68, (byte)70, 26.5m, 79.8m, 7.4m },
                    { 19, 1, 3, new DateTime(2022, 3, 30, 0, 0, 0, 0, DateTimeKind.Local), (byte)52, (byte)52, -35.1m, -31.1m, 12.3m },
                    { 20, 1, 1, new DateTime(2022, 3, 31, 0, 0, 0, 0, DateTimeKind.Local), (byte)84, (byte)70, 35.3m, 95.6m, 18.8m },
                    { 21, 1, 0, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Local), (byte)28, (byte)8, 47.5m, 117.5m, 3.1m },
                    { 22, 1, 4, new DateTime(2022, 4, 2, 0, 0, 0, 0, DateTimeKind.Local), (byte)26, (byte)80, 33.2m, 91.7m, 2.0m },
                    { 23, 1, 2, new DateTime(2022, 4, 3, 0, 0, 0, 0, DateTimeKind.Local), (byte)52, (byte)99, -46.1m, -51.0m, 14.5m },
                    { 24, 1, 3, new DateTime(2022, 4, 4, 0, 0, 0, 0, DateTimeKind.Local), (byte)40, (byte)24, -8.5m, 16.7m, 5.5m },
                    { 25, 1, 0, new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Local), (byte)62, (byte)98, -23.3m, -9.9m, 17.8m },
                    { 26, 1, 1, new DateTime(2022, 4, 6, 0, 0, 0, 0, DateTimeKind.Local), (byte)56, (byte)87, -7.6m, 18.4m, 12.8m },
                    { 27, 1, 0, new DateTime(2022, 4, 7, 0, 0, 0, 0, DateTimeKind.Local), (byte)24, (byte)87, 11.2m, 52.2m, 18.7m },
                    { 28, 1, 0, new DateTime(2022, 4, 8, 0, 0, 0, 0, DateTimeKind.Local), (byte)76, (byte)35, -27.2m, -16.9m, 3.1m },
                    { 29, 1, 2, new DateTime(2022, 4, 9, 0, 0, 0, 0, DateTimeKind.Local), (byte)45, (byte)92, -37.0m, -34.6m, 6.7m },
                    { 30, 1, 5, new DateTime(2022, 4, 10, 0, 0, 0, 0, DateTimeKind.Local), (byte)99, (byte)26, 24.6m, 76.3m, 9.8m },
                    { 31, 1, 2, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), (byte)73, (byte)8, 39.3m, 102.7m, 5.6m },
                    { 32, 1, 3, new DateTime(2022, 4, 12, 0, 0, 0, 0, DateTimeKind.Local), (byte)71, (byte)28, -5.7m, 21.8m, 14.8m },
                    { 33, 1, 0, new DateTime(2022, 4, 13, 0, 0, 0, 0, DateTimeKind.Local), (byte)40, (byte)94, 9.8m, 49.6m, 9.9m },
                    { 34, 1, 1, new DateTime(2022, 4, 14, 0, 0, 0, 0, DateTimeKind.Local), (byte)20, (byte)45, 16.1m, 61.0m, 1.7m },
                    { 35, 2, 2, new DateTime(2022, 3, 16, 0, 0, 0, 0, DateTimeKind.Local), (byte)13, (byte)9, 45.3m, 113.5m, 9.9m },
                    { 36, 2, 2, new DateTime(2022, 3, 17, 0, 0, 0, 0, DateTimeKind.Local), (byte)56, (byte)75, -2.2m, 28.1m, 17.6m },
                    { 37, 2, 2, new DateTime(2022, 3, 18, 0, 0, 0, 0, DateTimeKind.Local), (byte)42, (byte)54, 11.1m, 51.9m, 14.2m },
                    { 38, 2, 4, new DateTime(2022, 3, 19, 0, 0, 0, 0, DateTimeKind.Local), (byte)19, (byte)55, -14.5m, 5.8m, 8.4m },
                    { 39, 2, 2, new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Local), (byte)55, (byte)80, 13.0m, 55.3m, 2.1m },
                    { 40, 2, 4, new DateTime(2022, 3, 21, 0, 0, 0, 0, DateTimeKind.Local), (byte)76, (byte)58, 20.8m, 69.4m, 15.0m },
                    { 41, 2, 4, new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), (byte)98, (byte)3, -7.5m, 18.4m, 16.4m },
                    { 42, 2, 2, new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), (byte)14, (byte)59, 28.3m, 83.0m, 3.4m },
                    { 43, 2, 4, new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), (byte)33, (byte)71, -28.1m, -18.6m, 11.7m },
                    { 44, 2, 5, new DateTime(2022, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), (byte)26, (byte)91, 14.6m, 58.2m, 17.9m },
                    { 45, 2, 3, new DateTime(2022, 3, 26, 0, 0, 0, 0, DateTimeKind.Local), (byte)3, (byte)56, 35.7m, 96.2m, 2.0m },
                    { 46, 2, 3, new DateTime(2022, 3, 27, 0, 0, 0, 0, DateTimeKind.Local), (byte)92, (byte)23, 16.7m, 62.1m, 11.3m }
                });

            migrationBuilder.InsertData(
                table: "Weather",
                columns: new[] { "Id", "CityId", "Condition", "Date", "Humidity", "RainChance", "TempC", "TempF", "Wind" },
                values: new object[,]
                {
                    { 47, 2, 1, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Local), (byte)74, (byte)75, 6.6m, 43.8m, 9.0m },
                    { 48, 2, 4, new DateTime(2022, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), (byte)79, (byte)71, 17.8m, 64.1m, 0.6m },
                    { 49, 2, 0, new DateTime(2022, 3, 30, 0, 0, 0, 0, DateTimeKind.Local), (byte)4, (byte)63, 24.9m, 76.7m, 11.2m },
                    { 50, 2, 4, new DateTime(2022, 3, 31, 0, 0, 0, 0, DateTimeKind.Local), (byte)65, (byte)54, 40.9m, 105.6m, 0.4m },
                    { 51, 2, 2, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Local), (byte)70, (byte)85, 30.7m, 87.3m, 19.0m },
                    { 52, 2, 0, new DateTime(2022, 4, 2, 0, 0, 0, 0, DateTimeKind.Local), (byte)66, (byte)21, 46.4m, 115.4m, 10.4m },
                    { 53, 2, 0, new DateTime(2022, 4, 3, 0, 0, 0, 0, DateTimeKind.Local), (byte)95, (byte)60, -49.3m, -56.7m, 13.0m },
                    { 54, 2, 1, new DateTime(2022, 4, 4, 0, 0, 0, 0, DateTimeKind.Local), (byte)14, (byte)80, -20.3m, -4.5m, 18.6m },
                    { 55, 2, 3, new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Local), (byte)95, (byte)19, -35.5m, -31.8m, 18.4m },
                    { 56, 2, 4, new DateTime(2022, 4, 6, 0, 0, 0, 0, DateTimeKind.Local), (byte)27, (byte)86, 40.6m, 105.1m, 12.7m },
                    { 57, 2, 2, new DateTime(2022, 4, 7, 0, 0, 0, 0, DateTimeKind.Local), (byte)59, (byte)47, -48.3m, -55.0m, 4.8m },
                    { 58, 2, 5, new DateTime(2022, 4, 8, 0, 0, 0, 0, DateTimeKind.Local), (byte)50, (byte)43, -34.1m, -29.4m, 15.8m },
                    { 59, 2, 5, new DateTime(2022, 4, 9, 0, 0, 0, 0, DateTimeKind.Local), (byte)26, (byte)62, -43.4m, -46.1m, 11.6m },
                    { 60, 2, 5, new DateTime(2022, 4, 10, 0, 0, 0, 0, DateTimeKind.Local), (byte)99, (byte)86, 1.7m, 35.1m, 6.6m },
                    { 61, 2, 3, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), (byte)49, (byte)11, -46.3m, -51.4m, 6.2m },
                    { 62, 2, 5, new DateTime(2022, 4, 12, 0, 0, 0, 0, DateTimeKind.Local), (byte)28, (byte)34, -40.5m, -41.0m, 8.0m },
                    { 63, 2, 0, new DateTime(2022, 4, 13, 0, 0, 0, 0, DateTimeKind.Local), (byte)76, (byte)19, -35.2m, -31.4m, 19.8m },
                    { 64, 2, 4, new DateTime(2022, 4, 14, 0, 0, 0, 0, DateTimeKind.Local), (byte)98, (byte)97, 18.8m, 65.9m, 17.2m },
                    { 65, 3, 3, new DateTime(2022, 3, 16, 0, 0, 0, 0, DateTimeKind.Local), (byte)89, (byte)51, 34.7m, 94.5m, 2.8m },
                    { 66, 3, 3, new DateTime(2022, 3, 17, 0, 0, 0, 0, DateTimeKind.Local), (byte)87, (byte)49, 5.0m, 41.1m, 3.0m },
                    { 67, 3, 4, new DateTime(2022, 3, 18, 0, 0, 0, 0, DateTimeKind.Local), (byte)96, (byte)65, 0.1m, 32.2m, 0.6m },
                    { 68, 3, 0, new DateTime(2022, 3, 19, 0, 0, 0, 0, DateTimeKind.Local), (byte)5, (byte)15, -26.1m, -14.9m, 12.0m },
                    { 69, 3, 3, new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Local), (byte)9, (byte)48, 8.6m, 47.5m, 10.6m },
                    { 70, 3, 3, new DateTime(2022, 3, 21, 0, 0, 0, 0, DateTimeKind.Local), (byte)70, (byte)2, -17.6m, 0.4m, 0.7m },
                    { 71, 3, 3, new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), (byte)27, (byte)5, 20.4m, 68.6m, 8.1m },
                    { 72, 3, 5, new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), (byte)12, (byte)58, -36.2m, -33.2m, 7.8m },
                    { 73, 3, 5, new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), (byte)79, (byte)49, -38.3m, -37.0m, 3.2m },
                    { 74, 3, 4, new DateTime(2022, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), (byte)52, (byte)93, 40.3m, 104.5m, 0.6m },
                    { 75, 3, 1, new DateTime(2022, 3, 26, 0, 0, 0, 0, DateTimeKind.Local), (byte)59, (byte)73, 25.5m, 77.8m, 15.7m },
                    { 76, 3, 3, new DateTime(2022, 3, 27, 0, 0, 0, 0, DateTimeKind.Local), (byte)84, (byte)32, -31.0m, -23.8m, 11.6m },
                    { 77, 3, 1, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Local), (byte)23, (byte)21, 37.9m, 100.3m, 8.0m },
                    { 78, 3, 0, new DateTime(2022, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), (byte)23, (byte)73, -36.1m, -32.9m, 18.1m },
                    { 79, 3, 0, new DateTime(2022, 3, 30, 0, 0, 0, 0, DateTimeKind.Local), (byte)45, (byte)98, 26.6m, 79.9m, 8.6m },
                    { 80, 3, 4, new DateTime(2022, 3, 31, 0, 0, 0, 0, DateTimeKind.Local), (byte)40, (byte)92, -34.6m, -30.2m, 0.5m },
                    { 81, 3, 3, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Local), (byte)6, (byte)47, -42.5m, -44.6m, 10.6m },
                    { 82, 3, 5, new DateTime(2022, 4, 2, 0, 0, 0, 0, DateTimeKind.Local), (byte)37, (byte)19, 20.7m, 69.3m, 0.3m },
                    { 83, 3, 4, new DateTime(2022, 4, 3, 0, 0, 0, 0, DateTimeKind.Local), (byte)59, (byte)99, 7.4m, 45.2m, 1.9m },
                    { 84, 3, 0, new DateTime(2022, 4, 4, 0, 0, 0, 0, DateTimeKind.Local), (byte)31, (byte)87, -47.0m, -52.6m, 15.2m },
                    { 85, 3, 3, new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Local), (byte)16, (byte)69, -29.5m, -21.0m, 13.3m },
                    { 86, 3, 1, new DateTime(2022, 4, 6, 0, 0, 0, 0, DateTimeKind.Local), (byte)18, (byte)80, 2.5m, 36.5m, 6.1m },
                    { 87, 3, 0, new DateTime(2022, 4, 7, 0, 0, 0, 0, DateTimeKind.Local), (byte)77, (byte)56, -41.9m, -43.4m, 0.8m },
                    { 88, 3, 2, new DateTime(2022, 4, 8, 0, 0, 0, 0, DateTimeKind.Local), (byte)8, (byte)58, -49.2m, -56.5m, 0.2m }
                });

            migrationBuilder.InsertData(
                table: "Weather",
                columns: new[] { "Id", "CityId", "Condition", "Date", "Humidity", "RainChance", "TempC", "TempF", "Wind" },
                values: new object[,]
                {
                    { 89, 3, 5, new DateTime(2022, 4, 9, 0, 0, 0, 0, DateTimeKind.Local), (byte)0, (byte)3, 0.5m, 32.8m, 1.4m },
                    { 90, 3, 5, new DateTime(2022, 4, 10, 0, 0, 0, 0, DateTimeKind.Local), (byte)2, (byte)29, 35.6m, 96.0m, 19.9m },
                    { 91, 3, 4, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), (byte)72, (byte)92, -23.4m, -10.2m, 18.7m },
                    { 92, 3, 0, new DateTime(2022, 4, 12, 0, 0, 0, 0, DateTimeKind.Local), (byte)15, (byte)66, -23.6m, -10.5m, 19.6m },
                    { 93, 3, 4, new DateTime(2022, 4, 13, 0, 0, 0, 0, DateTimeKind.Local), (byte)99, (byte)11, 16.2m, 61.2m, 19.3m },
                    { 94, 3, 2, new DateTime(2022, 4, 14, 0, 0, 0, 0, DateTimeKind.Local), (byte)15, (byte)51, 15.1m, 59.1m, 17.1m },
                    { 95, 4, 2, new DateTime(2022, 3, 16, 0, 0, 0, 0, DateTimeKind.Local), (byte)4, (byte)78, 34.3m, 93.7m, 7.6m },
                    { 96, 4, 3, new DateTime(2022, 3, 17, 0, 0, 0, 0, DateTimeKind.Local), (byte)10, (byte)4, -30.1m, -22.3m, 12.0m },
                    { 97, 4, 0, new DateTime(2022, 3, 18, 0, 0, 0, 0, DateTimeKind.Local), (byte)73, (byte)44, 28.8m, 83.8m, 15.7m },
                    { 98, 4, 1, new DateTime(2022, 3, 19, 0, 0, 0, 0, DateTimeKind.Local), (byte)57, (byte)23, -46.7m, -52.1m, 14.8m },
                    { 99, 4, 5, new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Local), (byte)47, (byte)88, 10.0m, 50.1m, 19.6m },
                    { 100, 4, 5, new DateTime(2022, 3, 21, 0, 0, 0, 0, DateTimeKind.Local), (byte)70, (byte)11, -29.2m, -20.6m, 8.9m },
                    { 101, 4, 5, new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), (byte)85, (byte)45, 4.3m, 39.7m, 8.4m },
                    { 102, 4, 2, new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), (byte)20, (byte)37, 32.0m, 89.6m, 13.5m },
                    { 103, 4, 5, new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), (byte)8, (byte)35, 35.5m, 96.0m, 15.5m },
                    { 104, 4, 1, new DateTime(2022, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), (byte)25, (byte)50, -32.7m, -26.8m, 5.9m },
                    { 105, 4, 0, new DateTime(2022, 3, 26, 0, 0, 0, 0, DateTimeKind.Local), (byte)19, (byte)87, 32.7m, 90.8m, 2.0m },
                    { 106, 4, 3, new DateTime(2022, 3, 27, 0, 0, 0, 0, DateTimeKind.Local), (byte)72, (byte)2, -3.4m, 25.9m, 1.2m },
                    { 107, 4, 0, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Local), (byte)4, (byte)56, 37.5m, 99.5m, 10.9m },
                    { 108, 4, 4, new DateTime(2022, 3, 29, 0, 0, 0, 0, DateTimeKind.Local), (byte)7, (byte)0, 48.5m, 119.3m, 8.4m },
                    { 109, 4, 1, new DateTime(2022, 3, 30, 0, 0, 0, 0, DateTimeKind.Local), (byte)95, (byte)38, 7.0m, 44.6m, 18.7m },
                    { 110, 4, 3, new DateTime(2022, 3, 31, 0, 0, 0, 0, DateTimeKind.Local), (byte)49, (byte)30, -39.1m, -38.4m, 7.5m },
                    { 111, 4, 2, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Local), (byte)53, (byte)31, -34.3m, -29.7m, 11.5m },
                    { 112, 4, 5, new DateTime(2022, 4, 2, 0, 0, 0, 0, DateTimeKind.Local), (byte)59, (byte)75, -36.0m, -32.7m, 13.3m },
                    { 113, 4, 5, new DateTime(2022, 4, 3, 0, 0, 0, 0, DateTimeKind.Local), (byte)1, (byte)26, 49.2m, 120.5m, 1.5m },
                    { 114, 4, 4, new DateTime(2022, 4, 4, 0, 0, 0, 0, DateTimeKind.Local), (byte)63, (byte)40, -2.7m, 27.1m, 9.7m },
                    { 115, 4, 2, new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Local), (byte)17, (byte)43, 49.0m, 120.2m, 17.0m },
                    { 116, 4, 4, new DateTime(2022, 4, 6, 0, 0, 0, 0, DateTimeKind.Local), (byte)7, (byte)8, -39.0m, -38.3m, 19.3m },
                    { 117, 4, 3, new DateTime(2022, 4, 7, 0, 0, 0, 0, DateTimeKind.Local), (byte)99, (byte)92, 27.1m, 80.8m, 14.2m },
                    { 118, 4, 5, new DateTime(2022, 4, 8, 0, 0, 0, 0, DateTimeKind.Local), (byte)71, (byte)27, 31.6m, 88.9m, 12.1m },
                    { 119, 4, 0, new DateTime(2022, 4, 9, 0, 0, 0, 0, DateTimeKind.Local), (byte)54, (byte)9, -36.7m, -34.0m, 12.0m },
                    { 120, 4, 1, new DateTime(2022, 4, 10, 0, 0, 0, 0, DateTimeKind.Local), (byte)87, (byte)66, 19.8m, 67.6m, 18.3m },
                    { 121, 4, 5, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), (byte)68, (byte)44, -8.8m, 16.2m, 19.6m },
                    { 122, 4, 5, new DateTime(2022, 4, 12, 0, 0, 0, 0, DateTimeKind.Local), (byte)15, (byte)8, 21.2m, 70.1m, 8.9m },
                    { 123, 4, 1, new DateTime(2022, 4, 13, 0, 0, 0, 0, DateTimeKind.Local), (byte)69, (byte)70, 30.9m, 87.7m, 1.7m },
                    { 124, 4, 1, new DateTime(2022, 4, 14, 0, 0, 0, 0, DateTimeKind.Local), (byte)88, (byte)13, -22.3m, -8.1m, 7.7m }
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
