using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AssignmentEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssignmentEntities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeadLine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaboratoryId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignmentEntities_LaboratoryEntities_LaboratoryId",
                        column: x => x.LaboratoryId,
                        principalTable: "LaboratoryEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentAssigments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<long>(type: "bigint", nullable: true),
                    AssignmentId = table.Column<long>(type: "bigint", nullable: true),
                    Grade = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAssigments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAssigments_AssignmentEntities_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "AssignmentEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentAssigments_StudentEntities_StudentId",
                        column: x => x.StudentId,
                        principalTable: "StudentEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentEntities_LaboratoryId",
                table: "AssignmentEntities",
                column: "LaboratoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssigments_AssignmentId",
                table: "StudentAssigments",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssigments_StudentId",
                table: "StudentAssigments",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentAssigments");

            migrationBuilder.DropTable(
                name: "AssignmentEntities");
        }
    }
}
