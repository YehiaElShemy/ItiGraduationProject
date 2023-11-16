using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Project.Migrations
{
    /// <inheritdoc />
    public partial class intittt2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DoctorId1",
                table: "Doctor_Patients",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientId1",
                table: "Doctor_Patients",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientId1",
                table: "Clinic_Patients",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoctorId1",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientId1",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "7a065aa2-2ad4-4723-8c75-1ac01ef0488c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "b4b7282f-53e5-4ab6-929e-eaf3b21dfc8f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "962ea509-15d4-42e2-83b3-adf5bbec42c7");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_Patients_DoctorId1",
                table: "Doctor_Patients",
                column: "DoctorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_Patients_PatientId1",
                table: "Doctor_Patients",
                column: "PatientId1");

            migrationBuilder.CreateIndex(
                name: "IX_Clinic_Patients_PatientId1",
                table: "Clinic_Patients",
                column: "PatientId1");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId1",
                table: "Appointments",
                column: "DoctorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId1",
                table: "Appointments",
                column: "PatientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_DoctorId1",
                table: "Appointments",
                column: "DoctorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_PatientId1",
                table: "Appointments",
                column: "PatientId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinic_Patients_AspNetUsers_PatientId1",
                table: "Clinic_Patients",
                column: "PatientId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Patients_AspNetUsers_DoctorId1",
                table: "Doctor_Patients",
                column: "DoctorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Patients_AspNetUsers_PatientId1",
                table: "Doctor_Patients",
                column: "PatientId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_DoctorId1",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_PatientId1",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Clinic_Patients_AspNetUsers_PatientId1",
                table: "Clinic_Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Patients_AspNetUsers_DoctorId1",
                table: "Doctor_Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Patients_AspNetUsers_PatientId1",
                table: "Doctor_Patients");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_Patients_DoctorId1",
                table: "Doctor_Patients");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_Patients_PatientId1",
                table: "Doctor_Patients");

            migrationBuilder.DropIndex(
                name: "IX_Clinic_Patients_PatientId1",
                table: "Clinic_Patients");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_DoctorId1",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_PatientId1",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "DoctorId1",
                table: "Doctor_Patients");

            migrationBuilder.DropColumn(
                name: "PatientId1",
                table: "Doctor_Patients");

            migrationBuilder.DropColumn(
                name: "PatientId1",
                table: "Clinic_Patients");

            migrationBuilder.DropColumn(
                name: "DoctorId1",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "PatientId1",
                table: "Appointments");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "a6167cf9-9656-4de8-8680-4fac327d3070");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "65482b56-5c15-4397-8397-93b3406c26b5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "c57de0e7-9154-4aee-9425-2ed8c6096503");
        }
    }
}
