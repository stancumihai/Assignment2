using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class StudentAssignmentsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAssigments_AssignmentEntities_AssignmentId",
                table: "StudentAssigments");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAssigments_StudentEntities_StudentId",
                table: "StudentAssigments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAssigments",
                table: "StudentAssigments");

            migrationBuilder.RenameTable(
                name: "StudentAssigments",
                newName: "StudentAssigmentsEntities");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAssigments_StudentId",
                table: "StudentAssigmentsEntities",
                newName: "IX_StudentAssigmentsEntities_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAssigments_AssignmentId",
                table: "StudentAssigmentsEntities",
                newName: "IX_StudentAssigmentsEntities_AssignmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAssigmentsEntities",
                table: "StudentAssigmentsEntities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAssigmentsEntities_AssignmentEntities_AssignmentId",
                table: "StudentAssigmentsEntities",
                column: "AssignmentId",
                principalTable: "AssignmentEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAssigmentsEntities_StudentEntities_StudentId",
                table: "StudentAssigmentsEntities",
                column: "StudentId",
                principalTable: "StudentEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAssigmentsEntities_AssignmentEntities_AssignmentId",
                table: "StudentAssigmentsEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAssigmentsEntities_StudentEntities_StudentId",
                table: "StudentAssigmentsEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAssigmentsEntities",
                table: "StudentAssigmentsEntities");

            migrationBuilder.RenameTable(
                name: "StudentAssigmentsEntities",
                newName: "StudentAssigments");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAssigmentsEntities_StudentId",
                table: "StudentAssigments",
                newName: "IX_StudentAssigments_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAssigmentsEntities_AssignmentId",
                table: "StudentAssigments",
                newName: "IX_StudentAssigments_AssignmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAssigments",
                table: "StudentAssigments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAssigments_AssignmentEntities_AssignmentId",
                table: "StudentAssigments",
                column: "AssignmentId",
                principalTable: "AssignmentEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAssigments_StudentEntities_StudentId",
                table: "StudentAssigments",
                column: "StudentId",
                principalTable: "StudentEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
