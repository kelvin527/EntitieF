using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace Pelicula.Api.Migrations
{
    public partial class ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Biografia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ubicacion = table.Column<Point>(type: "geography", precision: 9, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnCartelera = table.Column<bool>(type: "bit", nullable: false),
                    FechaEstreno = table.Column<DateTime>(type: "date", nullable: false),
                    PostelrURL = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CineOfertas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateTime>(type: "date", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "date", nullable: false),
                    PorcentajeDescuento = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    CineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CineOfertas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CineOfertas_Cines_CineId",
                        column: x => x.CineId,
                        principalTable: "Cines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalaDeCines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoSalaDeCine = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Precio = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    CineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaDeCines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaDeCines_Cines_CineId",
                        column: x => x.CineId,
                        principalTable: "Cines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneroPelicula",
                columns: table => new
                {
                    GenerosId = table.Column<int>(type: "int", nullable: false),
                    PeliculasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneroPelicula", x => new { x.GenerosId, x.PeliculasId });
                    table.ForeignKey(
                        name: "FK_GeneroPelicula_Generos_GenerosId",
                        column: x => x.GenerosId,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneroPelicula_Peliculas_PeliculasId",
                        column: x => x.PeliculasId,
                        principalTable: "Peliculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeliculaActor",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    Personaje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Orden = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaActor", x => new { x.PeliculaId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_PeliculaActor_Actor_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculaActor_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeliculaSalaDeCine",
                columns: table => new
                {
                    PeliculasId = table.Column<int>(type: "int", nullable: false),
                    SalaDeCinesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaSalaDeCine", x => new { x.PeliculasId, x.SalaDeCinesId });
                    table.ForeignKey(
                        name: "FK_PeliculaSalaDeCine_Peliculas_PeliculasId",
                        column: x => x.PeliculasId,
                        principalTable: "Peliculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculaSalaDeCine_SalaDeCines_SalaDeCinesId",
                        column: x => x.SalaDeCinesId,
                        principalTable: "SalaDeCines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CineOfertas_CineId",
                table: "CineOfertas",
                column: "CineId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GeneroPelicula_PeliculasId",
                table: "GeneroPelicula",
                column: "PeliculasId");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaActor_ActorId",
                table: "PeliculaActor",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaSalaDeCine_SalaDeCinesId",
                table: "PeliculaSalaDeCine",
                column: "SalaDeCinesId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaDeCines_CineId",
                table: "SalaDeCines",
                column: "CineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CineOfertas");

            migrationBuilder.DropTable(
                name: "GeneroPelicula");

            migrationBuilder.DropTable(
                name: "PeliculaActor");

            migrationBuilder.DropTable(
                name: "PeliculaSalaDeCine");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.DropTable(
                name: "SalaDeCines");

            migrationBuilder.DropTable(
                name: "Cines");
        }
    }
}
