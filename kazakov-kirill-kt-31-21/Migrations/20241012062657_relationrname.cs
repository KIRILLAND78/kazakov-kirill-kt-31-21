using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kazakov_kirill_kt_31_21.Migrations
{
    /// <inheritdoc />
    public partial class relationrname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorSubject_cd_professor_ProfessorsId",
                table: "ProfessorSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorSubject_cd_subject_SubjectsId",
                table: "ProfessorSubject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessorSubject",
                table: "ProfessorSubject");

            migrationBuilder.RenameTable(
                name: "ProfessorSubject",
                newName: "cd_subject_professor");

            migrationBuilder.RenameIndex(
                name: "IX_ProfessorSubject_SubjectsId",
                table: "cd_subject_professor",
                newName: "IX_cd_subject_professor_SubjectsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cd_subject_professor",
                table: "cd_subject_professor",
                columns: new[] { "ProfessorsId", "SubjectsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_cd_subject_professor_cd_professor_ProfessorsId",
                table: "cd_subject_professor",
                column: "ProfessorsId",
                principalTable: "cd_professor",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cd_subject_professor_cd_subject_SubjectsId",
                table: "cd_subject_professor",
                column: "SubjectsId",
                principalTable: "cd_subject",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cd_subject_professor_cd_professor_ProfessorsId",
                table: "cd_subject_professor");

            migrationBuilder.DropForeignKey(
                name: "FK_cd_subject_professor_cd_subject_SubjectsId",
                table: "cd_subject_professor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cd_subject_professor",
                table: "cd_subject_professor");

            migrationBuilder.RenameTable(
                name: "cd_subject_professor",
                newName: "ProfessorSubject");

            migrationBuilder.RenameIndex(
                name: "IX_cd_subject_professor_SubjectsId",
                table: "ProfessorSubject",
                newName: "IX_ProfessorSubject_SubjectsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessorSubject",
                table: "ProfessorSubject",
                columns: new[] { "ProfessorsId", "SubjectsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorSubject_cd_professor_ProfessorsId",
                table: "ProfessorSubject",
                column: "ProfessorsId",
                principalTable: "cd_professor",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorSubject_cd_subject_SubjectsId",
                table: "ProfessorSubject",
                column: "SubjectsId",
                principalTable: "cd_subject",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
