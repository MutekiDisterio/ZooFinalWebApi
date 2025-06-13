using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Zoo.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationWithSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimalTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnimalTypeName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VolunteersDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DepartmentName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteersDepartment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnimalTypeId = table.Column<int>(type: "integer", nullable: false),
                    AnimalTypeId1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cages_AnimalTypes_AnimalTypeId",
                        column: x => x.AnimalTypeId,
                        principalTable: "AnimalTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cages_AnimalTypes_AnimalTypeId1",
                        column: x => x.AnimalTypeId1,
                        principalTable: "AnimalTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OwnerId = table.Column<int>(type: "integer", nullable: true),
                    AnimalTypeId = table.Column<int>(type: "integer", nullable: false),
                    AnimalTypeId1 = table.Column<int>(type: "integer", nullable: true),
                    OwnerId1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_AnimalTypes_AnimalTypeId",
                        column: x => x.AnimalTypeId,
                        principalTable: "AnimalTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animals_AnimalTypes_AnimalTypeId1",
                        column: x => x.AnimalTypeId1,
                        principalTable: "AnimalTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Animals_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Animals_Owners_OwnerId1",
                        column: x => x.OwnerId1,
                        principalTable: "Owners",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AnimalsCages",
                columns: table => new
                {
                    CageId = table.Column<int>(type: "integer", nullable: false),
                    AnimalId = table.Column<int>(type: "integer", nullable: false),
                    AnimalId1 = table.Column<int>(type: "integer", nullable: true),
                    CageId1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalsCages", x => new { x.CageId, x.AnimalId });
                    table.ForeignKey(
                        name: "FK_AnimalsCages_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalsCages_Animals_AnimalId1",
                        column: x => x.AnimalId1,
                        principalTable: "Animals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnimalsCages_Cages_CageId",
                        column: x => x.CageId,
                        principalTable: "Cages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalsCages_Cages_CageId1",
                        column: x => x.CageId1,
                        principalTable: "Cages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Volunteers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    AnimalId = table.Column<int>(type: "integer", nullable: true),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    AnimalId1 = table.Column<int>(type: "integer", nullable: true),
                    VolunteerDepartmentId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Volunteers_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Volunteers_Animals_AnimalId1",
                        column: x => x.AnimalId1,
                        principalTable: "Animals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Volunteers_VolunteersDepartment_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "VolunteersDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Volunteers_VolunteersDepartment_VolunteerDepartmentId",
                        column: x => x.VolunteerDepartmentId,
                        principalTable: "VolunteersDepartment",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AnimalTypes",
                columns: new[] { "Id", "AnimalTypeName" },
                values: new object[,]
                {
                    { 1, "Mammals" },
                    { 2, "Fish" },
                    { 3, "Birds" },
                    { 4, "Reptiles" },
                    { 5, "Amphibians" },
                    { 6, "Invertebrates" }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Address", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Sofia, 2 Zdrave str.", "Georgi Georgiev", "0883456586" },
                    { 2, "Varna, 5 Dragoman str.", "Petur Petrov", "0897635645" },
                    { 3, "Gabrovo, 21 Vasil Levski str.", "Gergana Mancheva", "0897412123" },
                    { 4, null, "Kaloqn Stoqnov", "0878325642" },
                    { 5, "Plovdiv", "Stamat Kostov", "0857231001" },
                    { 6, "Sofia, 213 Pirin str.", "Milena Dragomirova", "0876542123" },
                    { 7, "Sliven, 54 Struma str.", "Kiril Peshev", "0838654111" },
                    { 8, "Stara Zagora, 2 Trakia str.", "Krasen Lyubenov", "0788120333" },
                    { 9, "Varna, 45 Devnya str.", "Martin Genchev", "0899452325" },
                    { 10, "Burgas, 21 Alexandrovska str.", "Kamelia Yancheva", "0876213799" },
                    { 11, null, "Metodi Dimitrov", "0894568889" },
                    { 12, "Kalofer, 2 Mladost str.", "Matei Kirilov", "0978235641" },
                    { 13, "Blagoevgrad, 2 Akacia str.", "Dobrin Krustev", "0978235641" },
                    { 14, "Gorna Oryahovitsa, 12 Angel Georgiev str.", "Kaloyan Dobrev", "0896523145" },
                    { 15, "Sofia, 156 Mladost str.", "Miroslav Kirilov", "0874563214" },
                    { 16, "Plovdiv, 18 Baba Tonka str.", "Krasen Stoyanov", "0896333258" },
                    { 17, "Provadia, 1 Buk str.", "Bozhidara Stoicheva", "0874569123" },
                    { 18, "Varna, 65 Vihren str.", "Petya Dobreva", "0874547896" },
                    { 19, "Varna, 118 General Kolev str.", "Kristina Kirova", "0888655632" },
                    { 20, "Burgas, 15 Glarus str.", "Mila Sotirova", "0877456222" },
                    { 21, "Sofia, 35 Detelina str.", "Grigor Litov", "0899366584" },
                    { 22, "Sliven, 8 Dobrotitsa str.", "Karolina Dukova", "0894562123" },
                    { 23, "Petrich, 9 Zora str.", "Ivan Fotinov", "0879654125" },
                    { 24, "Varna, 29 Dunav str.", "Anelia Mihova", "0897856147" },
                    { 25, "Sofia, 22 Karamfil str.", "Stanislav Peshev", "0889699599" },
                    { 26, "Burgas, 15 Marek str.", "Borislava Kamenova", "0877477112" }
                });

            migrationBuilder.InsertData(
                table: "VolunteersDepartment",
                columns: new[] { "Id", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "Guest engagement" },
                    { 2, "Education program assistant" },
                    { 3, "Zoo events" },
                    { 4, "Animal encounters" },
                    { 5, "Interpretive volunteer" },
                    { 6, "Keeper aide" },
                    { 7, "Animal handler" },
                    { 8, "Horticulture" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "AnimalTypeId", "AnimalTypeId1", "BirthDate", "Name", "OwnerId", "OwnerId1" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2017, 7, 17, 0, 0, 0, 0, DateTimeKind.Utc), "Brown bear", 3, null },
                    { 2, 1, null, new DateTime(2010, 1, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Chimpanzee", 6, null },
                    { 3, 1, null, new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Chinchilla", 11, null },
                    { 4, 1, null, new DateTime(2009, 5, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Elephant", 4, null },
                    { 5, 1, null, new DateTime(2018, 6, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Lion", 10, null },
                    { 6, 1, null, new DateTime(2011, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), "Rhinoceros", 2, null },
                    { 7, 1, null, new DateTime(2018, 3, 9, 0, 0, 0, 0, DateTimeKind.Utc), "Wolf", 7, null },
                    { 8, 1, null, new DateTime(2017, 4, 17, 0, 0, 0, 0, DateTimeKind.Utc), "Leopard", 4, null },
                    { 9, 1, null, new DateTime(2015, 9, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Fennec Fox", 26, null },
                    { 10, 1, null, new DateTime(2021, 11, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Giant Panda", 18, null },
                    { 11, 1, null, new DateTime(2017, 9, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Hippo", null, null },
                    { 12, 1, null, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Koala", 24, null },
                    { 13, 2, null, new DateTime(2020, 11, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Pumpkinseed Sunfish", 10, null },
                    { 14, 2, null, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Banded Archer Fish", null, null },
                    { 15, 2, null, new DateTime(2021, 1, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Cichlid", 5, null },
                    { 16, 2, null, new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Koi", null, null },
                    { 17, 2, null, new DateTime(2019, 10, 17, 0, 0, 0, 0, DateTimeKind.Utc), "West African Lungfish", 4, null },
                    { 18, 2, null, new DateTime(2018, 2, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Leopard Shark", 16, null },
                    { 19, 3, null, new DateTime(2017, 10, 31, 0, 0, 0, 0, DateTimeKind.Utc), "Tufted Puffin", 8, null },
                    { 20, 3, null, new DateTime(2019, 8, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Saddlebill Stork", null, null },
                    { 21, 3, null, new DateTime(2016, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Ostrich", 4, null },
                    { 22, 3, null, new DateTime(2014, 6, 29, 0, 0, 0, 0, DateTimeKind.Utc), "Bald Eagle", 12, null },
                    { 23, 3, null, new DateTime(2018, 11, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Swan Goose", 9, null },
                    { 24, 3, null, new DateTime(2019, 2, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Northern Pintail Duck", 6, null },
                    { 25, 3, null, new DateTime(2017, 7, 17, 0, 0, 0, 0, DateTimeKind.Utc), "African Penguin", null, null },
                    { 26, 3, null, new DateTime(2019, 4, 27, 0, 0, 0, 0, DateTimeKind.Utc), "American Kestrel", 18, null },
                    { 27, 3, null, new DateTime(2014, 12, 19, 0, 0, 0, 0, DateTimeKind.Utc), "California Condor", 16, null },
                    { 28, 4, null, new DateTime(2009, 9, 26, 0, 0, 0, 0, DateTimeKind.Utc), "African Spurred Tortoise", 7, null },
                    { 29, 4, null, new DateTime(2016, 7, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Anaconda", 10, null },
                    { 30, 4, null, new DateTime(2015, 8, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Boa", null, null },
                    { 31, 4, null, new DateTime(2018, 10, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Chameleon", null, null },
                    { 32, 4, null, new DateTime(2016, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Crocodilian", 11, null },
                    { 33, 4, null, new DateTime(2019, 4, 29, 0, 0, 0, 0, DateTimeKind.Utc), "Iguana", 6, null },
                    { 34, 4, null, new DateTime(2020, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Lizard", 7, null },
                    { 35, 4, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Tuatara", 14, null },
                    { 36, 4, null, new DateTime(2019, 4, 26, 0, 0, 0, 0, DateTimeKind.Utc), "Woma Python", 19, null },
                    { 37, 4, null, new DateTime(2017, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Rattlesnake", 19, null },
                    { 38, 5, null, new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Utc), "Goliath Frog", null, null },
                    { 39, 5, null, new DateTime(2020, 7, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Poison Frog", null, null },
                    { 40, 5, null, new DateTime(2022, 3, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Mantella", 9, null },
                    { 41, 5, null, new DateTime(2021, 6, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Surinam Toad", 11, null },
                    { 42, 5, null, new DateTime(2019, 1, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Axolotl", 12, null },
                    { 43, 5, null, new DateTime(2021, 9, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Panamanian Golden Frog", 23, null },
                    { 44, 6, null, new DateTime(2020, 5, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Desert Hairy Scorpion", null, null },
                    { 45, 6, null, new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Madagascar Hissing Cockroach", 7, null },
                    { 46, 6, null, new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Sunburst Diving Beetle", 9, null }
                });

            migrationBuilder.InsertData(
                table: "Cages",
                columns: new[] { "Id", "AnimalTypeId", "AnimalTypeId1" },
                values: new object[,]
                {
                    { 1, 2, null },
                    { 2, 3, null },
                    { 3, 6, null },
                    { 4, 2, null },
                    { 5, 4, null },
                    { 6, 3, null },
                    { 7, 1, null },
                    { 8, 5, null },
                    { 9, 5, null },
                    { 10, 2, null },
                    { 11, 4, null },
                    { 12, 5, null },
                    { 13, 5, null },
                    { 14, 6, null },
                    { 15, 1, null },
                    { 16, 1, null },
                    { 17, 2, null },
                    { 18, 2, null },
                    { 19, 3, null },
                    { 20, 4, null },
                    { 21, 1, null },
                    { 22, 6, null },
                    { 23, 4, null },
                    { 24, 4, null },
                    { 25, 2, null },
                    { 26, 1, null },
                    { 27, 1, null },
                    { 28, 4, null },
                    { 29, 3, null },
                    { 30, 5, null },
                    { 31, 4, null },
                    { 32, 1, null },
                    { 33, 3, null },
                    { 34, 1, null },
                    { 35, 5, null },
                    { 36, 3, null },
                    { 37, 1, null },
                    { 38, 1, null },
                    { 39, 3, null },
                    { 40, 5, null },
                    { 41, 1, null },
                    { 42, 2, null },
                    { 43, 5, null },
                    { 44, 4, null },
                    { 45, 3, null },
                    { 46, 3, null },
                    { 47, 2, null },
                    { 48, 1, null },
                    { 49, 1, null },
                    { 50, 5, null },
                    { 51, 4, null },
                    { 52, 1, null },
                    { 53, 4, null },
                    { 54, 2, null },
                    { 55, 3, null }
                });

            migrationBuilder.InsertData(
                table: "Volunteers",
                columns: new[] { "Id", "Address", "AnimalId", "AnimalId1", "DepartmentId", "Name", "PhoneNumber", "VolunteerDepartmentId" },
                values: new object[,]
                {
                    { 9, "Gorna Oryahovitsa, 5 Otez Paisii str.", null, null, 4, "Paskal Shopov", "0888987110", null },
                    { 14, "Varna, 2 Elin Pelin str.", null, null, 7, "Vasil Vasilev", "0896321023", null },
                    { 19, "Sofia , 15 Lyulyak str.", null, null, 2, "Dilyana Stoeva", "0889412025", null }
                });

            migrationBuilder.InsertData(
                table: "AnimalsCages",
                columns: new[] { "AnimalId", "CageId", "AnimalId1", "CageId1" },
                values: new object[,]
                {
                    { 13, 1, null, null },
                    { 19, 2, null, null },
                    { 44, 3, null, null },
                    { 32, 5, null, null },
                    { 24, 6, null, null },
                    { 5, 7, null, null },
                    { 41, 8, null, null },
                    { 38, 9, null, null },
                    { 16, 10, null, null },
                    { 28, 11, null, null },
                    { 39, 12, null, null },
                    { 45, 14, null, null },
                    { 7, 15, null, null },
                    { 12, 16, null, null },
                    { 14, 18, null, null },
                    { 26, 19, null, null },
                    { 36, 20, null, null },
                    { 9, 21, null, null },
                    { 46, 22, null, null },
                    { 34, 23, null, null },
                    { 37, 24, null, null },
                    { 1, 26, null, null },
                    { 10, 27, null, null },
                    { 33, 28, null, null },
                    { 20, 29, null, null },
                    { 31, 31, null, null },
                    { 8, 32, null, null },
                    { 27, 33, null, null },
                    { 3, 34, null, null },
                    { 42, 35, null, null },
                    { 22, 36, null, null },
                    { 4, 37, null, null },
                    { 11, 38, null, null },
                    { 21, 39, null, null },
                    { 6, 41, null, null },
                    { 18, 42, null, null },
                    { 40, 43, null, null },
                    { 35, 44, null, null },
                    { 25, 46, null, null },
                    { 15, 47, null, null },
                    { 2, 49, null, null },
                    { 43, 50, null, null },
                    { 30, 51, null, null },
                    { 29, 53, null, null },
                    { 17, 54, null, null },
                    { 23, 55, null, null }
                });

            migrationBuilder.InsertData(
                table: "Volunteers",
                columns: new[] { "Id", "Address", "AnimalId", "AnimalId1", "DepartmentId", "Name", "PhoneNumber", "VolunteerDepartmentId" },
                values: new object[,]
                {
                    { 1, "Sofia , 213 Tsarigradsko shose str.", 7, null, 2, "Kiril Kostadinov", "0896541233", null },
                    { 2, "Plovdiv, 15 Arda str.", 14, null, 1, "Boyan Boyanov", "0896321546", null },
                    { 3, "Kalofer, 2 Tsar Simeon str.", 4, null, 3, "Mariya Petkova", "0874563201", null },
                    { 4, null, 8, null, 4, "Svilen Mitev", "0877300100", null },
                    { 5, "Sofia, 26 Vasil Levski str.", 7, null, 8, "Dimitrichka Stateva", "0888632123", null },
                    { 6, "Varna, 2 Dobrotitsa str.", 11, null, 3, "Anton Antonov", "0877456123", null },
                    { 7, "Sofia, 54 Hristo Botev str.", 1, null, 2, "Yanko Totev", "0896369258", null },
                    { 8, null, 5, null, 6, "Katerina Dimitrova", "0874589665", null },
                    { 10, "Sofia, 39 Bratya Buxton str.", 31, null, 3, "Darina Petrova", "0889654236", null },
                    { 11, "Karlovo, 2 Breza str.", 29, null, 1, "Maya Stoyanova", "0886544444", null },
                    { 12, "Sofia, 61 Veles str.", 27, null, 5, "Svilen Moskov", "0879510023", null },
                    { 13, "Varna, 23 Devnya str.", 16, null, 6, "Georgi Georgiev", "0879654456", null },
                    { 15, "Montana, 2 Zora str.", 2, null, 2, "Krasimira Boyanova", "0879541236", null },
                    { 16, "Sofia, 37 Iglika str.", 33, null, 1, "Teodora Stanoeva", "0887986002", null },
                    { 17, "Sliven, 6 Krim str.", 18, null, 5, "Gabriel Radkov", "0889745102", null },
                    { 18, "Tryavna, 21 Loza str.", 11, null, 2, "Mihail Boev", "0896336554", null },
                    { 20, "Varna, 158 Mariya Luiza str.", 16, null, 1, "Yulian Bratoev", "0897665895", null },
                    { 21, "Ahtopol, 11 Mir str.", 13, null, 3, "Petya Dobreva", "0888541236", null },
                    { 22, "Sofia, 6 Neven str.", 19, null, 2, "Zdravko Asenov", "0889652365", null },
                    { 23, "Veliko Turnovo, 54 Odrin str.", 22, null, 3, "Stefan Lazarov", "0887456215", null },
                    { 24, "Plovdiv, 16 Pirin str.", 34, null, 6, "Radoslava Mihailova", "0887456325", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_AnimalTypeId",
                table: "Animals",
                column: "AnimalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_AnimalTypeId1",
                table: "Animals",
                column: "AnimalTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_OwnerId",
                table: "Animals",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_OwnerId1",
                table: "Animals",
                column: "OwnerId1");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalsCages_AnimalId",
                table: "AnimalsCages",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalsCages_AnimalId1",
                table: "AnimalsCages",
                column: "AnimalId1");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalsCages_CageId1",
                table: "AnimalsCages",
                column: "CageId1");

            migrationBuilder.CreateIndex(
                name: "IX_Cages_AnimalTypeId",
                table: "Cages",
                column: "AnimalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cages_AnimalTypeId1",
                table: "Cages",
                column: "AnimalTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_AnimalId",
                table: "Volunteers",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_AnimalId1",
                table: "Volunteers",
                column: "AnimalId1");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_DepartmentId",
                table: "Volunteers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_VolunteerDepartmentId",
                table: "Volunteers",
                column: "VolunteerDepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalsCages");

            migrationBuilder.DropTable(
                name: "Volunteers");

            migrationBuilder.DropTable(
                name: "Cages");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "VolunteersDepartment");

            migrationBuilder.DropTable(
                name: "AnimalTypes");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
