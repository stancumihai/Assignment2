using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AllEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryEntities_ProfessorEntities_ProfessorId",
                table: "LaboratoryEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentLaboratories_LaboratoryEntities_LaboratoryId",
                table: "StudentLaboratories");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentLaboratories_StudentEntities_StudentId",
                table: "StudentLaboratories");

            migrationBuilder.DropIndex(
                name: "IX_LaboratoryEntities_ProfessorId",
                table: "LaboratoryEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentLaboratories",
                table: "StudentLaboratories");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "LaboratoryEntities");

            migrationBuilder.RenameTable(
                name: "StudentLaboratories",
                newName: "StudentLaboratoriesEntities");

            migrationBuilder.RenameIndex(
                name: "IX_StudentLaboratories_StudentId",
                table: "StudentLaboratoriesEntities",
                newName: "IX_StudentLaboratoriesEntities_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentLaboratories_LaboratoryId",
                table: "StudentLaboratoriesEntities",
                newName: "IX_StudentLaboratoriesEntities_LaboratoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentLaboratoriesEntities",
                table: "StudentLaboratoriesEntities",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProfessorLaboratoriesEntities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessorId = table.Column<long>(type: "bigint", nullable: true),
                    LaboratoryId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorLaboratoriesEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessorLaboratoriesEntities_LaboratoryEntities_LaboratoryId",
                        column: x => x.LaboratoryId,
                        principalTable: "LaboratoryEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfessorLaboratoriesEntities_ProfessorEntities_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "ProfessorEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorLaboratoriesEntities_LaboratoryId",
                table: "ProfessorLaboratoriesEntities",
                column: "LaboratoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorLaboratoriesEntities_ProfessorId",
                table: "ProfessorLaboratoriesEntities",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentLaboratoriesEntities_LaboratoryEntities_LaboratoryId",
                table: "StudentLaboratoriesEntities",
                column: "LaboratoryId",
                principalTable: "LaboratoryEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentLaboratoriesEntities_StudentEntities_StudentId",
                table: "StudentLaboratoriesEntities",
                column: "StudentId",
                principalTable: "StudentEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentLaboratoriesEntities_LaboratoryEntities_LaboratoryId",
                table: "StudentLaboratoriesEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentLaboratoriesEntities_StudentEntities_StudentId",
                table: "StudentLaboratoriesEntities");

            migrationBuilder.DropTable(
                name: "ProfessorLaboratoriesEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentLaboratoriesEntities",
                table: "StudentLaboratoriesEntities");

            migrationBuilder.RenameTable(
                name: "StudentLaboratoriesEntities",
                newName: "StudentLaboratories");

            migrationBuilder.RenameIndex(
                name: "IX_StudentLaboratoriesEntities_StudentId",
                table: "StudentLaboratories",
                newName: "IX_StudentLaboratories_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentLaboratoriesEntities_LaboratoryId",
                table: "StudentLaboratories",
                newName: "IX_StudentLaboratories_LaboratoryId");

            migrationBuilder.AddColumn<long>(
                name: "ProfessorId",
                table: "LaboratoryEntities",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentLaboratories",
                table: "StudentLaboratories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryEntities_ProfessorId",
                table: "LaboratoryEntities",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryEntities_ProfessorEntities_ProfessorId",
                table: "LaboratoryEntities",
                column: "ProfessorId",
                principalTable: "ProfessorEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentLaboratories_LaboratoryEntities_LaboratoryId",
                table: "StudentLaboratories",
                column: "LaboratoryId",
                principalTable: "LaboratoryEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentLaboratories_StudentEntities_StudentId",
                table: "StudentLaboratories",
                column: "StudentId",
                principalTable: "StudentEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
