using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Project.Migrations
{
    /// <inheritdoc />
    public partial class init23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "DoctroSpecialists",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "f7dee59e-27bd-496c-bacf-6e64a442b4d5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "f7d7700b-6ed3-4e95-9a37-38283f227967");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "3089a54f-bf25-42d4-a61d-e5787d0f2bc2");

            migrationBuilder.CreateIndex(
                name: "IX_DoctroSpecialists_ApplicationUserId",
                table: "DoctroSpecialists",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctroSpecialists_AspNetUsers_ApplicationUserId",
                table: "DoctroSpecialists",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctroSpecialists_AspNetUsers_ApplicationUserId",
                table: "DoctroSpecialists");

            migrationBuilder.DropIndex(
                name: "IX_DoctroSpecialists_ApplicationUserId",
                table: "DoctroSpecialists");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "DoctroSpecialists");

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "9f1995fc-81f4-4660-812c-360973fb1c58");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "31a67e97-018c-4fbe-8702-ac4fe163f49e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "04a920bc-ed41-4928-ae6f-35d69b6240f7");
        }
    }
}
