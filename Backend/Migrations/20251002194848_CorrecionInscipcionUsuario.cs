using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class CorrecionInscipcionUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inscripciones",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Inscripciones",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Inscripciones");

            migrationBuilder.DropColumn(
                name: "Dni",
                table: "Inscripciones");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Inscripciones");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Inscripciones");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Usuarios",
                newName: "Dni");

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Usuarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Inscripciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Capacitaciones",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaHora",
                value: new DateTime(2025, 10, 12, 16, 48, 46, 513, DateTimeKind.Local).AddTicks(204));

            migrationBuilder.UpdateData(
                table: "Capacitaciones",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaHora",
                value: new DateTime(2025, 10, 22, 16, 48, 46, 513, DateTimeKind.Local).AddTicks(237));

            migrationBuilder.UpdateData(
                table: "Inscripciones",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Importe", "TipoInscripcionId", "UsuarioId" },
                values: new object[] { 3000m, 3, 1 });

            migrationBuilder.UpdateData(
                table: "Inscripciones",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CapacitacionId", "Importe", "UsuarioId" },
                values: new object[] { 2, 6000m, 2 });

            migrationBuilder.UpdateData(
                table: "Inscripciones",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CapacitacionId", "Importe", "TipoInscripcionId", "UsuarioId" },
                values: new object[] { 1, 10000m, 1, 3 });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Apellido", "Dni", "Email", "Nombre", "TipoUsuario" },
                values: new object[] { "Pérez", "12345678", "juan.perez@email.com", "Juan", 0 });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Apellido", "Dni", "Email", "Nombre", "TipoUsuario" },
                values: new object[] { "García", "87654321", "maria.garcia@email.com", "María", 1 });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellido", "DeleteDate", "Dni", "Email", "IsDeleted", "Nombre", "TipoUsuario" },
                values: new object[] { 3, "López", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "11223344", "pedro.lopez@email.com", false, "Pedro", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_UsuarioId",
                table: "Inscripciones",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripciones_Usuarios_UsuarioId",
                table: "Inscripciones",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscripciones_Usuarios_UsuarioId",
                table: "Inscripciones");

            migrationBuilder.DropIndex(
                name: "IX_Inscripciones_UsuarioId",
                table: "Inscripciones");

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Inscripciones");

            migrationBuilder.RenameColumn(
                name: "Dni",
                table: "Usuarios",
                newName: "Password");

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Inscripciones",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Dni",
                table: "Inscripciones",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Inscripciones",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Inscripciones",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Capacitaciones",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaHora",
                value: new DateTime(2025, 8, 29, 18, 30, 3, 794, DateTimeKind.Local).AddTicks(3578));

            migrationBuilder.UpdateData(
                table: "Capacitaciones",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaHora",
                value: new DateTime(2025, 9, 8, 18, 30, 3, 794, DateTimeKind.Local).AddTicks(3603));

            migrationBuilder.UpdateData(
                table: "Inscripciones",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Apellido", "Dni", "Email", "Importe", "Nombre", "TipoInscripcionId" },
                values: new object[] { "Gómez", "12345678", "carlos.gomez@gmail.com", 10000m, "Carlos", 1 });

            migrationBuilder.UpdateData(
                table: "Inscripciones",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Apellido", "CapacitacionId", "Dni", "Email", "Importe", "Nombre" },
                values: new object[] { "Martínez", 1, "87654321", "ana.martinez@gmail.com", 5000m, "Ana" });

            migrationBuilder.UpdateData(
                table: "Inscripciones",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Apellido", "CapacitacionId", "Dni", "Email", "Importe", "Nombre", "TipoInscripcionId" },
                values: new object[] { "Pérez", 2, "11223344", "juan.perez@gmail.com", 4000m, "Juan", 3 });

            migrationBuilder.InsertData(
                table: "Inscripciones",
                columns: new[] { "Id", "Acreditado", "Apellido", "CapacitacionId", "Dni", "Email", "Importe", "IsDeleted", "Nombre", "Pagado", "TipoInscripcionId", "UsuarioCobroId" },
                values: new object[,]
                {
                    { 4, false, "Lopez", 2, "44332211", "maria.lopez@gmail.com", 3000m, false, "Maria", false, 4, null },
                    { 5, false, "Fernandez", 2, "55667788", "luis.fernandez@gmail.com", 12000m, false, "Luis", false, 1, null }
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Nombre", "Password", "TipoUsuario" },
                values: new object[] { "admin@gmail.com", "Admin", "admin123", 2 });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Nombre", "Password", "TipoUsuario" },
                values: new object[] { "perez@gmail.com", "Juan Perez", "juan123", 0 });
        }
    }
}
