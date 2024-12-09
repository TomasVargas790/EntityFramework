using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace project_ef_c_.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("cb62f99c-82b5-47c0-8f44-72e9566b377f"), null, "Actividades personales", 50 },
                    { new Guid("dede8ef4-a93f-4b7c-a8a8-770c21446b08"), null, "Actividades pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "Prioridad", "Titulo" },
                values: new object[,]
                {
                    { new Guid("9e59edc3-632a-43ef-b647-3560b57fd4cd"), new Guid("cb62f99c-82b5-47c0-8f44-72e9566b377f"), null, new DateTime(2024, 12, 8, 22, 7, 19, 321, DateTimeKind.Local).AddTicks(7573), 0, "Terminar de ver pelicula en Netflix" },
                    { new Guid("af6bc98f-7e3c-42ff-826b-825bbf89d7a8"), new Guid("dede8ef4-a93f-4b7c-a8a8-770c21446b08"), null, new DateTime(2024, 12, 8, 22, 7, 19, 320, DateTimeKind.Local).AddTicks(9407), 1, "Pago de servicios publicos" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("9e59edc3-632a-43ef-b647-3560b57fd4cd"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("af6bc98f-7e3c-42ff-826b-825bbf89d7a8"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("cb62f99c-82b5-47c0-8f44-72e9566b377f"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("dede8ef4-a93f-4b7c-a8a8-770c21446b08"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
