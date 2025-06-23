using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DPN.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class OverrideRoleNameAsRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Name",
                table: "AspNetRoles",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "RoleDescription" },
                values: new object[,]
                {
                    { "64b47966-5dd4-4cae-ad86-de5152361efc", null, "Miembro", "MIEMBRO", "Usuario con acceso restringido" },
                    { "fa1aa086-9bf2-4281-b2c5-c149c73d28ca", null, "Admin", "ADMIN", "Superusuario" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "isSystemUser" },
                values: new object[,]
                {
                    { "2142774d-9f61-4a10-b03c-1675f7542d66", 0, "Managua, Managua", "4c14bea2-36d6-4edc-bc40-78c2e3603ede", "admin@correo.com", false, "Admin", "Del Sistem", false, null, "ADMIN@CORREO.COM", "ADMIN@CORREO.COM", "AQAAAAIAAYagAAAAEKH3IIDqTuAmMVlFA0P7eeYhAuiXU2tKjrtKA+D5FlwxQ69u1RVAvWDffv91yvsR+w==", "1234567890", false, "28dccb62-a270-47ad-a9e0-9c4c128684b0", false, "admin@correo.com", true },
                    { "b7d319a1-b308-4883-a366-30864f31536b", 0, "Managua, Managua", "61e625a6-89e7-4a68-886b-148e4b0d432e", "miembro@correo.com", false, "Miembro", "Del Sistem", false, null, "MIEMBRO@CORREO.COM", "MIEMBRO@CORREO.COM", "AQAAAAIAAYagAAAAEKn4Dx4z/vJdculqyDNWjZOtyr6BFZNxu671GCF7IIM+i2nQl0o/5reXoDnz43VNhA==", "1234567890", false, "51d89a15-6f34-41d6-b1bd-5c085204ffc4", false, "miembro@correo.com", false }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "fa1aa086-9bf2-4281-b2c5-c149c73d28ca", "2142774d-9f61-4a10-b03c-1675f7542d66" },
                    { "64b47966-5dd4-4cae-ad86-de5152361efc", "b7d319a1-b308-4883-a366-30864f31536b" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fa1aa086-9bf2-4281-b2c5-c149c73d28ca", "2142774d-9f61-4a10-b03c-1675f7542d66" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "64b47966-5dd4-4cae-ad86-de5152361efc", "b7d319a1-b308-4883-a366-30864f31536b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64b47966-5dd4-4cae-ad86-de5152361efc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa1aa086-9bf2-4281-b2c5-c149c73d28ca");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2142774d-9f61-4a10-b03c-1675f7542d66");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b7d319a1-b308-4883-a366-30864f31536b");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetRoles",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

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
    }
}
