using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ambulance.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChronicPatients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIO = table.Column<string>(nullable: true),
                    Age = table.Column<double>(nullable: false),
                    Diagnosis = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<string>(nullable: true),
                    FlatNumber = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    WhoCalled = table.Column<string>(nullable: true),
                    Urgency = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChronicPatients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dispatchers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispatchers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doktors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doktors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalAssistants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalAssistants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orderlies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orderlies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIO = table.Column<string>(nullable: true),
                    Age = table.Column<double>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<string>(nullable: true),
                    FlatNumber = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statisticians",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statisticians", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncidentalCalls",
                columns: table => new
                {
                    CallNumber = table.Column<double>(nullable: false),
                    PatientId = table.Column<int>(nullable: false),
                    Diagnosis = table.Column<string>(nullable: true),
                    Results = table.Column<string>(nullable: true),
                    AmbulanceBrigade_Number = table.Column<long>(nullable: true),
                    AmbulanceBrigade_Doktor = table.Column<string>(nullable: true),
                    AmbulanceBrigade_MedicalAssistants1 = table.Column<string>(nullable: true),
                    AmbulanceBrigade_MedicalAssistants2 = table.Column<string>(nullable: true),
                    AmbulanceBrigade_Orderly = table.Column<string>(nullable: true),
                    AmbulanceBrigade_Driver = table.Column<string>(nullable: true),
                    AmbulanceBrigade_BrigadeType = table.Column<string>(nullable: true),
                    AmbulanceBrigade_StationName = table.Column<string>(nullable: true),
                    DateTimeReception = table.Column<DateTime>(nullable: false),
                    TransferDateTime = table.Column<DateTime>(nullable: false),
                    ArrivalDateTime = table.Column<DateTime>(nullable: false),
                    DepartureDateTime = table.Column<DateTime>(nullable: false),
                    ComeBackDateTime = table.Column<DateTime>(nullable: false),
                    TransferringDispatcher = table.Column<string>(nullable: true),
                    ProcessingDispatcher = table.Column<string>(nullable: true),
                    KilometrageBefor = table.Column<int>(nullable: false),
                    KilometrageAfter = table.Column<int>(nullable: false),
                    Place = table.Column<string>(nullable: true),
                    CallNotes = table.Column<string>(nullable: true),
                    CallType = table.Column<string>(nullable: true),
                    Treatment = table.Column<string>(nullable: true),
                    ProcessedCallId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentalCalls", x => x.CallNumber);
                    table.ForeignKey(
                        name: "FK_IncidentalCalls_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcessedCalls",
                columns: table => new
                {
                    CallNumber = table.Column<double>(nullable: false),
                    PatientId = table.Column<int>(nullable: false),
                    Diagnosis = table.Column<string>(nullable: true),
                    Results = table.Column<string>(nullable: true),
                    AmbulanceBrigade_Number = table.Column<long>(nullable: true),
                    AmbulanceBrigade_Doktor = table.Column<string>(nullable: true),
                    AmbulanceBrigade_MedicalAssistants1 = table.Column<string>(nullable: true),
                    AmbulanceBrigade_MedicalAssistants2 = table.Column<string>(nullable: true),
                    AmbulanceBrigade_Orderly = table.Column<string>(nullable: true),
                    AmbulanceBrigade_Driver = table.Column<string>(nullable: true),
                    AmbulanceBrigade_BrigadeType = table.Column<string>(nullable: true),
                    AmbulanceBrigade_StationName = table.Column<string>(nullable: true),
                    DateTimeReception = table.Column<DateTime>(nullable: false),
                    TransferDateTime = table.Column<DateTime>(nullable: false),
                    ArrivalDateTime = table.Column<DateTime>(nullable: false),
                    DepartureDateTime = table.Column<DateTime>(nullable: false),
                    ComeBackDateTime = table.Column<DateTime>(nullable: false),
                    TransferringDispatcher = table.Column<string>(nullable: true),
                    ProcessingDispatcher = table.Column<string>(nullable: true),
                    KilometrageBefor = table.Column<int>(nullable: false),
                    KilometrageAfter = table.Column<int>(nullable: false),
                    Place = table.Column<string>(nullable: true),
                    CallNotes = table.Column<string>(nullable: true),
                    CallType = table.Column<string>(nullable: true),
                    Treatment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessedCalls", x => x.CallNumber);
                    table.ForeignKey(
                        name: "FK_ProcessedCalls_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IncidentalCalls_PatientId",
                table: "IncidentalCalls",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessedCalls_PatientId",
                table: "ProcessedCalls",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChronicPatients");

            migrationBuilder.DropTable(
                name: "Dispatchers");

            migrationBuilder.DropTable(
                name: "Doktors");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "IncidentalCalls");

            migrationBuilder.DropTable(
                name: "MedicalAssistants");

            migrationBuilder.DropTable(
                name: "Orderlies");

            migrationBuilder.DropTable(
                name: "ProcessedCalls");

            migrationBuilder.DropTable(
                name: "Statisticians");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
