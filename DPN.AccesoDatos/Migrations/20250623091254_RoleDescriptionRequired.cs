using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DPN.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RoleDescriptionRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "05495547-2a00-401b-aa41-b60e34ed5be6", "8ae508e1-33dc-467f-b280-fd635a5fda00" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "26f4131c-9186-41e4-ae07-d7dc230da108", "ac00b4d4-3782-4a81-b55e-1792d7cbb3be" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05495547-2a00-401b-aa41-b60e34ed5be6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26f4131c-9186-41e4-ae07-d7dc230da108");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8ae508e1-33dc-467f-b280-fd635a5fda00");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac00b4d4-3782-4a81-b55e-1792d7cbb3be");

            migrationBuilder.AlterColumn<string>(
                name: "RoleDescription",
                table: "AspNetRoles",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "RoleDescription" },
                values: new object[,]
                {
                    { "10449c12-6c19-4abe-8ab7-8581f5eea189", null, "Admin", "ADMIN", "Superusuario" },
                    { "b0f7e1e3-eb4a-4b22-b580-6f815e7391a0", null, "Miembro", "MIEMBRO", "Usuario con acceso restringido" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "isSystemUser" },
                values: new object[,]
                {
                    { "4629c83c-6f0c-4dcb-8209-8b42737b656c", 0, "Managua, Managua", "97094c71-a3d5-43b9-a559-77d07c60515b", "admin@correo.com", false, "Admin", "Del Sistem", false, null, "ADMIN@CORREO.COM", "ADMIN@CORREO.COM", "AQAAAAIAAYagAAAAEPSEb2YskJtWKLN25eIm0ZJgfE73NRYcV3XPncNFlbhcUZEt6D3mQ0/4KSx/khKu2g==", "1234567890", false, "820f877a-a77f-4018-9740-50419d474b80", false, "admin@correo.com", true },
                    { "5e460f11-22d3-4906-83d1-24a6bf7b7961", 0, "Managua, Managua", "136cea9b-4810-4690-b751-9b595975a0da", "miembro@correo.com", false, "Miembro", "Del Sistem", false, null, "MIEMBRO@CORREO.COM", "MIEMBRO@CORREO.COM", "AQAAAAIAAYagAAAAEBZFb8q6YBjmymzhpMtXOARivnSbbFKgEisvo5dJ1k1ZObCzbBYGp5w/iLUW81TF6Q==", "1234567890", false, "37ba83e5-e3bd-4034-ab42-873841da6a82", false, "miembro@correo.com", false }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "10449c12-6c19-4abe-8ab7-8581f5eea189", "4629c83c-6f0c-4dcb-8209-8b42737b656c" },
                    { "b0f7e1e3-eb4a-4b22-b580-6f815e7391a0", "5e460f11-22d3-4906-83d1-24a6bf7b7961" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "10449c12-6c19-4abe-8ab7-8581f5eea189", "4629c83c-6f0c-4dcb-8209-8b42737b656c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b0f7e1e3-eb4a-4b22-b580-6f815e7391a0", "5e460f11-22d3-4906-83d1-24a6bf7b7961" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10449c12-6c19-4abe-8ab7-8581f5eea189");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0f7e1e3-eb4a-4b22-b580-6f815e7391a0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4629c83c-6f0c-4dcb-8209-8b42737b656c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e460f11-22d3-4906-83d1-24a6bf7b7961");

            migrationBuilder.AlterColumn<string>(
                name: "RoleDescription",
                table: "AspNetRoles",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "RoleDescription" },
                values: new object[,]
                {
                    { "05495547-2a00-401b-aa41-b60e34ed5be6", null, "Admin", "ADMIN", "Superusuario" },
                    { "26f4131c-9186-41e4-ae07-d7dc230da108", null, "Miembro", "MIEMBRO", "Usuario con acceso restringido" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "isSystemUser" },
                values: new object[,]
                {
                    { "8ae508e1-33dc-467f-b280-fd635a5fda00", 0, "Managua, Managua", "bd91da19-6254-48c5-99a2-de2ab261576c", "admin@correo.com", false, "Admin", "Del Sistem", false, null, "ADMIN@CORREO.COM", "ADMIN@CORREO.COM", "AQAAAAIAAYagAAAAEM17Tvswh58HCFhbKnMRnNwwimuaNVuU+4gneXSKlibOojc9R94xv7UeMQAWk0tR4w==", "1234567890", false, "a60c4b3d-6a99-4ac6-8141-3db7c5f3c954", false, "admin@correo.com", true },
                    { "ac00b4d4-3782-4a81-b55e-1792d7cbb3be", 0, "Managua, Managua", "413d825f-84b7-4693-80a7-33d95172a5ba", "miembro@correo.com", false, "Miembro", "Del Sistem", false, null, "MIEMBRO@CORREO.COM", "MIEMBRO@CORREO.COM", "AQAAAAIAAYagAAAAEMSblOxdyPiujd05VvB1pfKv16JvoJO5uz2LxBWLcipBbb7bb158SAGye6RsyxwqUQ==", "1234567890", false, "ce32b540-8acc-4e98-b100-c78e6d5bb80d", false, "miembro@correo.com", false }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "05495547-2a00-401b-aa41-b60e34ed5be6", "8ae508e1-33dc-467f-b280-fd635a5fda00" },
                    { "26f4131c-9186-41e4-ae07-d7dc230da108", "ac00b4d4-3782-4a81-b55e-1792d7cbb3be" }
                });
        }
    }
}
