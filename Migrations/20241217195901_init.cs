using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dashbord.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clinicTable_DoctorTable_doctorId",
                table: "clinicTable");

            migrationBuilder.DropIndex(
                name: "IX_clinicTable_doctorId",
                table: "clinicTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorTable",
                table: "DoctorTable");

            migrationBuilder.DropColumn(
                name: "doctorId",
                table: "clinicTable");

            migrationBuilder.RenameTable(
                name: "DoctorTable",
                newName: "Doctor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctor",
                table: "Doctor",
                column: "doctorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctor",
                table: "Doctor");

            migrationBuilder.RenameTable(
                name: "Doctor",
                newName: "DoctorTable");

            migrationBuilder.AddColumn<int>(
                name: "doctorId",
                table: "clinicTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorTable",
                table: "DoctorTable",
                column: "doctorId");

            migrationBuilder.CreateIndex(
                name: "IX_clinicTable_doctorId",
                table: "clinicTable",
                column: "doctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_clinicTable_DoctorTable_doctorId",
                table: "clinicTable",
                column: "doctorId",
                principalTable: "DoctorTable",
                principalColumn: "doctorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
