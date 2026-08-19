using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taskflow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateIssueTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_IssueAggregate_IssueAggregateId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueAggregate_Project_ProjectId",
                table: "IssueAggregate");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueAggregate_User_AssignedTo",
                table: "IssueAggregate");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueAggregate_User_ReportedBy",
                table: "IssueAggregate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IssueAggregate",
                table: "IssueAggregate");

            migrationBuilder.RenameTable(
                name: "IssueAggregate",
                newName: "Issue");

            migrationBuilder.RenameIndex(
                name: "IX_IssueAggregate_ReportedBy",
                table: "Issue",
                newName: "IX_Issue_ReportedBy");

            migrationBuilder.RenameIndex(
                name: "IX_IssueAggregate_ProjectId",
                table: "Issue",
                newName: "IX_Issue_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_IssueAggregate_AssignedTo",
                table: "Issue",
                newName: "IX_Issue_AssignedTo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Issue",
                table: "Issue",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Issue_IssueAggregateId",
                table: "Comment",
                column: "IssueAggregateId",
                principalTable: "Issue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_Project_ProjectId",
                table: "Issue",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_User_AssignedTo",
                table: "Issue",
                column: "AssignedTo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_User_ReportedBy",
                table: "Issue",
                column: "ReportedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Issue_IssueAggregateId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Issue_Project_ProjectId",
                table: "Issue");

            migrationBuilder.DropForeignKey(
                name: "FK_Issue_User_AssignedTo",
                table: "Issue");

            migrationBuilder.DropForeignKey(
                name: "FK_Issue_User_ReportedBy",
                table: "Issue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Issue",
                table: "Issue");

            migrationBuilder.RenameTable(
                name: "Issue",
                newName: "IssueAggregate");

            migrationBuilder.RenameIndex(
                name: "IX_Issue_ReportedBy",
                table: "IssueAggregate",
                newName: "IX_IssueAggregate_ReportedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Issue_ProjectId",
                table: "IssueAggregate",
                newName: "IX_IssueAggregate_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Issue_AssignedTo",
                table: "IssueAggregate",
                newName: "IX_IssueAggregate_AssignedTo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IssueAggregate",
                table: "IssueAggregate",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_IssueAggregate_IssueAggregateId",
                table: "Comment",
                column: "IssueAggregateId",
                principalTable: "IssueAggregate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IssueAggregate_Project_ProjectId",
                table: "IssueAggregate",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IssueAggregate_User_AssignedTo",
                table: "IssueAggregate",
                column: "AssignedTo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IssueAggregate_User_ReportedBy",
                table: "IssueAggregate",
                column: "ReportedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
