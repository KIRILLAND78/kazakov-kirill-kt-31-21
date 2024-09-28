using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace kazakov_kirill_kt_31_21.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_post",
                columns: table => new
                {
                    id = table.Column<long>(type: "int8", nullable: false, comment: "Идентификатор должности")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar", maxLength: 64, nullable: false, comment: "Название должности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_post_post_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cd_rank",
                columns: table => new
                {
                    id = table.Column<long>(type: "int8", nullable: false, comment: "Идентификатор ученой степени")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar", maxLength: 64, nullable: false, comment: "Название ученой степени")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_rank_rank_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cd_workload",
                columns: table => new
                {
                    id = table.Column<long>(type: "int8", nullable: false, comment: "Идентификатор учебной нагрузки")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar", maxLength: 64, nullable: false, comment: "Название учебной нагрузки"),
                    hours = table.Column<int>(type: "int4", nullable: false, comment: "Часы учебной нагрузки")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_workload_workload_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cd_subject",
                columns: table => new
                {
                    id = table.Column<long>(type: "int8", nullable: false, comment: "Идентификатор учебного предмета")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar", maxLength: 64, nullable: false, comment: "Название учебного предмета"),
                    workload_id = table.Column<long>(type: "int8", nullable: false, comment: "Идентификатор учебной нагрузки")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_subject_subject_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_k_workload_id",
                        column: x => x.workload_id,
                        principalTable: "cd_workload",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_faculty",
                columns: table => new
                {
                    id = table.Column<long>(type: "int8", nullable: false, comment: "Идентификатор кафедры")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar", maxLength: 64, nullable: false, comment: "Название кафедры"),
                    lead_professor_id = table.Column<long>(type: "int8", nullable: true, comment: "Идентификатор заведующего кафедрой, может быть null")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_faculty_faculty_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cd_professor",
                columns: table => new
                {
                    id = table.Column<long>(type: "int8", nullable: false, comment: "Идентификатор преподавателя")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar", maxLength: 64, nullable: false, comment: "Название кафедры"),
                    faculty_id = table.Column<long>(type: "int8", nullable: false, comment: "Идентификатор кафедры, в которой находится преподаватель"),
                    rank_id = table.Column<long>(type: "int8", nullable: false, comment: "Идентификатор ученой степени преподавателя"),
                    post_id = table.Column<long>(type: "int8", nullable: false, comment: "Идентификатор должности преподавателя")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_professor_professor_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_k_faculty_id",
                        column: x => x.faculty_id,
                        principalTable: "cd_faculty",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_k_post_id",
                        column: x => x.post_id,
                        principalTable: "cd_post",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_k_rank_id",
                        column: x => x.rank_id,
                        principalTable: "cd_rank",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorSubject",
                columns: table => new
                {
                    ProfessorsId = table.Column<long>(type: "int8", nullable: false),
                    SubjectsId = table.Column<long>(type: "int8", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorSubject", x => new { x.ProfessorsId, x.SubjectsId });
                    table.ForeignKey(
                        name: "FK_ProfessorSubject_cd_professor_ProfessorsId",
                        column: x => x.ProfessorsId,
                        principalTable: "cd_professor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessorSubject_cd_subject_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "cd_subject",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cd_faculty_lead_professor_id",
                table: "cd_faculty",
                column: "lead_professor_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cd_professor_faculty_id",
                table: "cd_professor",
                column: "faculty_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_professor_post_id",
                table: "cd_professor",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_professor_rank_id",
                table: "cd_professor",
                column: "rank_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_subject_workload_id",
                table: "cd_subject",
                column: "workload_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorSubject_SubjectsId",
                table: "ProfessorSubject",
                column: "SubjectsId");

            migrationBuilder.AddForeignKey(
                name: "fk_k_lead_professor_id",
                table: "cd_faculty",
                column: "lead_professor_id",
                principalTable: "cd_professor",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_k_lead_professor_id",
                table: "cd_faculty");

            migrationBuilder.DropTable(
                name: "ProfessorSubject");

            migrationBuilder.DropTable(
                name: "cd_subject");

            migrationBuilder.DropTable(
                name: "cd_workload");

            migrationBuilder.DropTable(
                name: "cd_professor");

            migrationBuilder.DropTable(
                name: "cd_faculty");

            migrationBuilder.DropTable(
                name: "cd_post");

            migrationBuilder.DropTable(
                name: "cd_rank");
        }
    }
}
