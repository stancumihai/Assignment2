using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class StudentsLaboratories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentLaboratories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaboratoryId = table.Column<long>(type: "bigint", nullable: true),
                    StudentId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLaboratories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentLaboratories_LaboratoryEntities_LaboratoryId",
                        column: x => x.LaboratoryId,
                        principalTable: "LaboratoryEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentLaboratories_StudentEntities_StudentId",
                        column: x => x.StudentId,
                        principalTable: "StudentEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentLaboratories_LaboratoryId",
                table: "StudentLaboratories",
                column: "LaboratoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLaboratories_StudentId",
                table: "StudentLaboratories",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentLaboratories");
        }
    }
}
