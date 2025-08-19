using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace efCore.Migrations
{
    /// <inheritdoc />
    public partial class AddTableTutor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseRegisters");

            migrationBuilder.AddColumn<int>(
                name: "TutorId",
                table: "Courses",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CourseRegisters",
                columns: table => new
                {
                    RegisterId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false),
                    RegisterTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseRegisters", x => x.RegisterId);
                    table.ForeignKey(
                        name: "FK_CourseRegisters_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseRegisters_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tutors",
                columns: table => new
                {
                    TutorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TutorName = table.Column<string>(type: "TEXT", nullable: true),
                    TutorSurname = table.Column<string>(type: "TEXT", nullable: true),
                    TutorEmail = table.Column<string>(type: "TEXT", nullable: true),
                    TutorPhone = table.Column<string>(type: "TEXT", nullable: true),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutors", x => x.TutorId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TutorId",
                table: "Courses",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRegisters_CourseId",
                table: "CourseRegisters",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRegisters_StudentId",
                table: "CourseRegisters",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Tutors_TutorId",
                table: "Courses",
                column: "TutorId",
                principalTable: "Tutors",
                principalColumn: "TutorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Tutors_TutorId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "CourseRegisters");

            migrationBuilder.DropTable(
                name: "Tutors");

            migrationBuilder.DropIndex(
                name: "IX_Courses_TutorId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "TutorId",
                table: "Courses");

            migrationBuilder.CreateTable(
                name: "CourseRegisters",
                columns: table => new
                {
                    ApplyId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ApplyTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CourseRegisters", x => x.ApplyId);
                });
        }
    }
}
