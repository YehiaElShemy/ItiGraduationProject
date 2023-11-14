using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Project.Migrations
{
    /// <inheritdoc />
    public partial class init2322 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSpecialists_AspNetUsers_DoctorId1",
                table: "DoctorSpecialists");

            migrationBuilder.DropIndex(
                name: "IX_DoctorSpecialists_DoctorId1",
                table: "DoctorSpecialists");

            migrationBuilder.DropColumn(
                name: "DoctorId1",
                table: "DoctorSpecialists");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "2c77a7a4-c5d9-4b8c-8748-0a7611c6b117");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "b2fc35d9-519d-4848-97a8-d1bcc7d917ae");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "7f07766f-40f0-4c90-99e9-492b4e940028");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DoctorId1",
                table: "DoctorSpecialists",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "e729e0f3-f78e-4040-bb4f-910e07965078");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "aeaa09fd-d0c9-4e82-976b-4839ca4f79d2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "33c031e9-9348-4f35-9a90-d7d0f1691c6b");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpecialists_DoctorId1",
                table: "DoctorSpecialists",
                column: "DoctorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSpecialists_AspNetUsers_DoctorId1",
                table: "DoctorSpecialists",
                column: "DoctorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
