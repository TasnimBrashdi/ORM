using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace College.Migrations
{
    /// <inheritdoc />
    public partial class addrelaitonship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Hostels_hosID",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "hosID",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "CourseFaculty",
                columns: table => new
                {
                    CoursesCId = table.Column<int>(type: "int", nullable: false),
                    FacultiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseFaculty", x => new { x.CoursesCId, x.FacultiesId });
                    table.ForeignKey(
                        name: "FK_CourseFaculty_Courses_CoursesCId",
                        column: x => x.CoursesCId,
                        principalTable: "Courses",
                        principalColumn: "CId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseFaculty_Faculties_FacultiesId",
                        column: x => x.FacultiesId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ExamsStudent",
                columns: table => new
                {
                    ExamsExCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentsSId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamsStudent", x => new { x.ExamsExCode, x.StudentsSId });
                    table.ForeignKey(
                        name: "FK_ExamsStudent_Exams_ExamsExCode",
                        column: x => x.ExamsExCode,
                        principalTable: "Exams",
                        principalColumn: "ExCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamsStudent_Students_StudentsSId",
                        column: x => x.StudentsSId,
                        principalTable: "Students",
                        principalColumn: "SId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseFaculty_FacultiesId",
                table: "CourseFaculty",
                column: "FacultiesId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamsStudent_StudentsSId",
                table: "ExamsStudent",
                column: "StudentsSId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Hostels_hosID",
                table: "Students",
                column: "hosID",
                principalTable: "Hostels",
                principalColumn: "HID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Hostels_hosID",
                table: "Students");

            migrationBuilder.DropTable(
                name: "CourseFaculty");

            migrationBuilder.DropTable(
                name: "ExamsStudent");

            migrationBuilder.AlterColumn<int>(
                name: "hosID",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Hostels_hosID",
                table: "Students",
                column: "hosID",
                principalTable: "Hostels",
                principalColumn: "HID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
