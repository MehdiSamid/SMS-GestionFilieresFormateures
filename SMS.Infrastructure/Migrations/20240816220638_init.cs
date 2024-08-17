using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Infrastructure.Migrations
{
    /// <inheritdoc />
<<<<<<<< HEAD:SMS.Infrastructure/Migrations/20240723130349_initial.cs
    public partial class initial : Migration
========
    public partial class init : Migration
>>>>>>>> 8738c67f59e9a520fb00cbea9c5683e48076eb3a:SMS.Infrastructure/Migrations/20240816195911_init.cs
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filieres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomFiliere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Niveau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duree = table.Column<int>(type: "int", nullable: false),
                    Capacite = table.Column<int>(type: "int", nullable: false),
                    GroupCapacity = table.Column<int>(type: "int", nullable: false),
                    FraisInscription = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontantMensuel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontantAnnuel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontantTrimestre = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filieres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Formateurs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialisation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Statut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formateurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdFiliere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUniteFormation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdGroupe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SeanceIndex = table.Column<int>(type: "int", nullable: false),
                    IdSalle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEmploi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdFormateur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Secteurs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secteurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitOfFormations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Semestre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Coefficient = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfFormations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emplois",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dateEmploi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    groupe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    semestre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    filiereId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdGroupe = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nbrSeance = table.Column<int>(type: "int", nullable: false),
                    breakStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    breakEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    breakRange = table.Column<int>(type: "int", nullable: false),
                    SeanceDuration = table.Column<int>(type: "int", nullable: false),
                    firstSeanceStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emplois", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emplois_Filieres_filiereId",
                        column: x => x.filiereId,
                        principalTable: "Filieres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Absences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idSeance = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idFormateur = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idStagaire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Absences_Formateurs_idFormateur",
                        column: x => x.idFormateur,
                        principalTable: "Formateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Absences_Seances_idSeance",
                        column: x => x.idSeance,
                        principalTable: "Seances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FiliereUnitOfFormations",
                columns: table => new
                {
                    FiliereId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitOfFormationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiliereUnitOfFormations", x => new { x.FiliereId, x.UnitOfFormationId });
                    table.ForeignKey(
                        name: "FK_FiliereUnitOfFormations_Filieres_FiliereId",
                        column: x => x.FiliereId,
                        principalTable: "Filieres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FiliereUnitOfFormations_UnitOfFormations_UnitOfFormationId",
                        column: x => x.UnitOfFormationId,
                        principalTable: "UnitOfFormations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Absences_idFormateur",
                table: "Absences",
                column: "idFormateur");

            migrationBuilder.CreateIndex(
                name: "IX_Absences_idSeance",
                table: "Absences",
                column: "idSeance");

            migrationBuilder.CreateIndex(
                name: "IX_Emplois_filiereId",
                table: "Emplois",
                column: "filiereId");

            migrationBuilder.CreateIndex(
                name: "IX_FiliereUnitOfFormations_UnitOfFormationId",
                table: "FiliereUnitOfFormations",
                column: "UnitOfFormationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Absences");

            migrationBuilder.DropTable(
                name: "Emplois");

            migrationBuilder.DropTable(
                name: "FiliereUnitOfFormations");

            migrationBuilder.DropTable(
                name: "Secteurs");

            migrationBuilder.DropTable(
                name: "Formateurs");

            migrationBuilder.DropTable(
                name: "Seances");

            migrationBuilder.DropTable(
                name: "Filieres");

            migrationBuilder.DropTable(
                name: "UnitOfFormations");
        }
    }
}
