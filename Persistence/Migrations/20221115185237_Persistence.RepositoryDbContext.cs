using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class PersistenceRepositoryDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cabinets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabinets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    SiteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CabinetId = table.Column<int>(type: "int", nullable: true),
                    SpecializationId = table.Column<int>(type: "int", nullable: true),
                    SiteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Cabinets_CabinetId",
                        column: x => x.CabinetId,
                        principalTable: "Cabinets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doctors_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doctors_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Cabinets",
                columns: new[] { "Id", "Number" },
                values: new object[,]
                {
                    { 1, 11 },
                    { 2, 12 },
                    { 3, 13 },
                    { 4, 14 },
                    { 5, 15 },
                    { 6, 16 }
                });

            migrationBuilder.InsertData(
                table: "Sites",
                columns: new[] { "Id", "Number" },
                values: new object[,]
                {
                    { 1, 11 },
                    { 2, 12 }
                });

            migrationBuilder.InsertData(
                table: "Specializations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 5, "Стоматолог" },
                    { 1, "Терапевт" },
                    { 2, "Аллерголог" },
                    { 3, "Офтальмолог" },
                    { 4, "Хирург" },
                    { 6, "Педиатр" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "CabinetId", "FIO", "SiteId", "SpecializationId" },
                values: new object[,]
                {
                    { 1, 1, "Лемешова А.Н.", 1, 1 },
                    { 2, 2, "Денисова Е.В", 1, 2 },
                    { 3, 3, "Ситникова О.В.", 2, 3 },
                    { 4, 4, "Муравьёва С. А.", 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address", "DateOfBirth", "FirstName", "Gender", "LastName", "MiddleName", "SiteId" },
                values: new object[,]
                {
                    { 8, "Улица Ломоносова, 59", new DateTime(2002, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Михаил", 1, "Свиридов", "Александрович", 1 },
                    { 7, "Улица Чехова, 2", new DateTime(1996, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", 1, "Воронов", "Петрович", 1 },
                    { 6, "Улица Чехова, 1", new DateTime(1994, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Семен", 1, "Степанов", "Иванович", 1 },
                    { 5, "Улица Ломоносова, 59", new DateTime(2006, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Иван", 1, "Селиванов", "Антонович", 2 },
                    { 3, "Улица Чехова, 2", new DateTime(1993, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Эдуард", 1, "Харитонов", "Михайлович", 2 },
                    { 2, "Улица Ломоносова, 61", new DateTime(2009, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Петр", 1, "Петров", "Петрович", 1 },
                    { 1, "Улица Чехова, 1", new DateTime(1994, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Иван", 1, "Иванов", "Иванович", 1 },
                    { 4, "Улица Чехова, 3", new DateTime(2000, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Вячеслав", 1, "Рыбаков", "Андреевич", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_CabinetId",
                table: "Doctors",
                column: "CabinetId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SiteId",
                table: "Doctors",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecializationId",
                table: "Doctors",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_SiteId",
                table: "Patients",
                column: "SiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Cabinets");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "Sites");
        }
    }
}
