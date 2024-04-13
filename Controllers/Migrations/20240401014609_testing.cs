using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstProject.Migrations
{
    /// <inheritdoc />
    public partial class testing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_Course_Crs_Id",
                table: "Instructor");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_Departments_Dept_Id",
                table: "Instructor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructor",
                table: "Instructor");

            migrationBuilder.RenameTable(
                name: "Instructor",
                newName: "Instructors");

            migrationBuilder.RenameIndex(
                name: "IX_Instructor_Dept_Id",
                table: "Instructors",
                newName: "IX_Instructors_Dept_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Instructor_Crs_Id",
                table: "Instructors",
                newName: "IX_Instructors_Crs_Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Course_Crs_Id",
                table: "Instructors",
                column: "Crs_Id",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Departments_Dept_Id",
                table: "Instructors",
                column: "Dept_Id",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Course_Crs_Id",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Departments_Dept_Id",
                table: "Instructors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors");

            migrationBuilder.RenameTable(
                name: "Instructors",
                newName: "Instructor");

            migrationBuilder.RenameIndex(
                name: "IX_Instructors_Dept_Id",
                table: "Instructor",
                newName: "IX_Instructor_Dept_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Instructors_Crs_Id",
                table: "Instructor",
                newName: "IX_Instructor_Crs_Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructor",
                table: "Instructor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_Course_Crs_Id",
                table: "Instructor",
                column: "Crs_Id",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_Departments_Dept_Id",
                table: "Instructor",
                column: "Dept_Id",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
