using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taskflow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class issueTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IssueAggregate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReportedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    AssignedTo = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueAggregate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueAggregate_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueAggregate_User_AssignedTo",
                        column: x => x.AssignedTo,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IssueAggregate_User_ReportedBy",
                        column: x => x.ReportedBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IssueAggregateId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_IssueAggregate_IssueAggregateId",
                        column: x => x.IssueAggregateId,
                        principalTable: "IssueAggregate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_IssueAggregateId",
                table: "Comment",
                column: "IssueAggregateId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueAggregate_AssignedTo",
                table: "IssueAggregate",
                column: "AssignedTo");

            migrationBuilder.CreateIndex(
                name: "IX_IssueAggregate_ProjectId",
                table: "IssueAggregate",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueAggregate_ReportedBy",
                table: "IssueAggregate",
                column: "ReportedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "IssueAggregate");
        }
    }
}
