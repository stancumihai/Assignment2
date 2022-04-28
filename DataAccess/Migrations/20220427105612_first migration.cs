using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LaboratoryEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaboratoryNumber = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Objectives = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratoryEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolesEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssignmentEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaboratoryId = table.Column<int>(type: "int", nullable: true),
                    DeadLine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "RoleEntityUserEntity",
                columns: table => new
                {
                    RolesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleEntityUserEntity", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RoleEntityUserEntity_RolesEntities_RolesId",
                        column: x => x.RolesId,
                        principalTable: "RolesEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleEntityUserEntity_UserEntities_UsersId",
                        column: x => x.UsersId,
                        principalTable: "UserEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hobby = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentEntities_UserEntities_UserId",
                        column: x => x.UserId,
                        principalTable: "UserEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRolesEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRolesEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRolesEntities_RolesEntities_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RolesEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRolesEntities_UserEntities_UserId",
                        column: x => x.UserId,
                        principalTable: "UserEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FinalResultEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalResultEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinalResultEntities_StudentEntities_StudentId",
                        column: x => x.StudentId,
                        principalTable: "StudentEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentLaboratoriesEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaboratoryId = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLaboratoriesEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentLaboratoriesEntities_LaboratoryEntities_LaboratoryId",
                        column: x => x.LaboratoryId,
                        principalTable: "LaboratoryEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentLaboratoriesEntities_StudentEntities_StudentId",
                        column: x => x.StudentId,
                        principalTable: "StudentEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubmissionEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentId = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    Github = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmissionEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubmissionEntities_AssignmentEntities_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "AssignmentEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubmissionEntities_StudentEntities_StudentId",
                        column: x => x.StudentId,
                        principalTable: "StudentEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GradingEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmissionId = table.Column<int>(type: "int", nullable: true),
                    Grade = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradingEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradingEntities_SubmissionEntities_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "SubmissionEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "LaboratoryEntities",
                columns: new[] { "Id", "Date", "Description", "LaboratoryNumber", "Objectives", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 29, 0, 0, 0, 0, DateTimeKind.Local), "Learning Architecture Laboratory 1", 1, "Learning Architecture", "Laboratory 1" },
                    { 2, new DateTime(2022, 4, 29, 0, 0, 0, 0, DateTimeKind.Local), "Learning Architecture 2 Laboratory 2", 2, "Learning Architecture 2", "Laboratory 2" },
                    { 3, new DateTime(2022, 4, 30, 0, 0, 0, 0, DateTimeKind.Local), "Learning Architecture 3 Laboratory 3", 3, "Learning Architecture 3", "Laboratory 3" },
                    { 4, new DateTime(2022, 4, 30, 0, 0, 0, 0, DateTimeKind.Local), "Learning Architecture 4 Laboratory 4", 4, "Learning Architecture 4", "Laboratory 4" },
                    { 5, new DateTime(2022, 4, 30, 0, 0, 0, 0, DateTimeKind.Local), "Learning Architecture 4 Laboratory 4", 4, "Learning Architecture 4", "Laboratory 4" }
                });

            migrationBuilder.InsertData(
                table: "UserEntities",
                columns: new[] { "Id", "Email", "Password" },
                values: new object[,]
                {
                    { 1, "1@yahoo.com", "1234" },
                    { 2, "2@yahoo.com", "1234" },
                    { 3, "3@yahoo.com", "1234" },
                    { 4, "4@yahoo.com", "1234" },
                    { 5, "5@yahoo.com", "1234" },
                    { 6, "5@yahoo.com", "1234" },
                    { 7, "6@yahoo.com", "1234" },
                    { 8, "7@yahoo.com", "1234" }
                });

            migrationBuilder.InsertData(
                table: "AssignmentEntities",
                columns: new[] { "Id", "DeadLine", "Description", "LaboratoryId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 27, 13, 56, 11, 553, DateTimeKind.Local).AddTicks(2469), "Assignment1", 1 },
                    { 2, new DateTime(2022, 4, 27, 13, 56, 11, 553, DateTimeKind.Local).AddTicks(3067), "Assignment1", 1 },
                    { 3, new DateTime(2022, 4, 27, 13, 56, 11, 553, DateTimeKind.Local).AddTicks(3100), "Assignment2", 2 },
                    { 4, new DateTime(2022, 4, 27, 13, 56, 11, 553, DateTimeKind.Local).AddTicks(3105), "Assignment2", 2 },
                    { 5, new DateTime(2022, 4, 27, 13, 56, 11, 553, DateTimeKind.Local).AddTicks(3109), "Assignment3", 3 },
                    { 6, new DateTime(2022, 4, 27, 13, 56, 11, 553, DateTimeKind.Local).AddTicks(3117), "Assignment3", 3 },
                    { 7, new DateTime(2022, 4, 27, 13, 56, 11, 553, DateTimeKind.Local).AddTicks(3122), "Assignment4", 4 },
                    { 8, new DateTime(2022, 4, 27, 13, 56, 11, 553, DateTimeKind.Local).AddTicks(3127), "Assignment4", 4 },
                    { 9, new DateTime(2022, 4, 27, 13, 56, 11, 553, DateTimeKind.Local).AddTicks(3131), "Assignment5", 5 },
                    { 10, new DateTime(2022, 4, 27, 13, 56, 11, 553, DateTimeKind.Local).AddTicks(3137), "Assignment5", 5 }
                });

            migrationBuilder.InsertData(
                table: "StudentEntities",
                columns: new[] { "Id", "FullName", "Group", "Hobby", "UserId" },
                values: new object[,]
                {
                    { 1, "student1", "30231", "asd", 2 },
                    { 2, "student2", "30231", "asd", 3 },
                    { 3, "student3", "30231", "asd", 4 },
                    { 4, "student4", "30231", "asd", 5 },
                    { 5, "student5", "30231", "asd", 6 }
                });

            migrationBuilder.InsertData(
                table: "StudentLaboratoriesEntities",
                columns: new[] { "Id", "LaboratoryId", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 2, 2 },
                    { 3, 3, 2 },
                    { 4, 1, 3 },
                    { 5, 2, 3 },
                    { 6, 3, 3 },
                    { 7, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "SubmissionEntities",
                columns: new[] { "Id", "AssignmentId", "Comment", "Github", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, "asd", "asd", 2 },
                    { 2, 2, "asd", "asd", 2 },
                    { 3, 3, "asd", "asd", 2 },
                    { 4, 1, "asd", "asd", 3 },
                    { 5, 2, "asd", "asd", 3 },
                    { 6, 3, "asd", "asd", 3 }
                });

            migrationBuilder.InsertData(
                table: "GradingEntities",
                columns: new[] { "Id", "Grade", "SubmissionId" },
                values: new object[,]
                {
                    { 1, 6f, 1 },
                    { 2, 6f, 2 },
                    { 3, 6f, 3 },
                    { 4, 5f, 4 },
                    { 5, 5f, 5 },
                    { 6, 5f, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentEntities_LaboratoryId",
                table: "AssignmentEntities",
                column: "LaboratoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalResultEntities_StudentId",
                table: "FinalResultEntities",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_GradingEntities_SubmissionId",
                table: "GradingEntities",
                column: "SubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleEntityUserEntity_UsersId",
                table: "RoleEntityUserEntity",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEntities_UserId",
                table: "StudentEntities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLaboratoriesEntities_LaboratoryId",
                table: "StudentLaboratoriesEntities",
                column: "LaboratoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLaboratoriesEntities_StudentId",
                table: "StudentLaboratoriesEntities",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmissionEntities_AssignmentId",
                table: "SubmissionEntities",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmissionEntities_StudentId",
                table: "SubmissionEntities",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRolesEntities_RoleId",
                table: "UserRolesEntities",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRolesEntities_UserId",
                table: "UserRolesEntities",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinalResultEntities");

            migrationBuilder.DropTable(
                name: "GradingEntities");

            migrationBuilder.DropTable(
                name: "RoleEntityUserEntity");

            migrationBuilder.DropTable(
                name: "StudentLaboratoriesEntities");

            migrationBuilder.DropTable(
                name: "UserRolesEntities");

            migrationBuilder.DropTable(
                name: "SubmissionEntities");

            migrationBuilder.DropTable(
                name: "RolesEntities");

            migrationBuilder.DropTable(
                name: "AssignmentEntities");

            migrationBuilder.DropTable(
                name: "StudentEntities");

            migrationBuilder.DropTable(
                name: "LaboratoryEntities");

            migrationBuilder.DropTable(
                name: "UserEntities");
        }
    }
}
