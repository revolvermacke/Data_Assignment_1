using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ProjectServiceDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectServiceEntity_Projects_ProjectId",
                table: "ProjectServiceEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectServiceEntity_Services_ServiceId",
                table: "ProjectServiceEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectServiceEntity",
                table: "ProjectServiceEntity");

            migrationBuilder.RenameTable(
                name: "ProjectServiceEntity",
                newName: "ProjectServices");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectServiceEntity_ServiceId",
                table: "ProjectServices",
                newName: "IX_ProjectServices_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectServiceEntity_ProjectId",
                table: "ProjectServices",
                newName: "IX_ProjectServices_ProjectId");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Services",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "ProjectServices",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectServices",
                table: "ProjectServices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectServices_Projects_ProjectId",
                table: "ProjectServices",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectServices_Services_ServiceId",
                table: "ProjectServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectServices_Projects_ProjectId",
                table: "ProjectServices");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectServices_Services_ServiceId",
                table: "ProjectServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectServices",
                table: "ProjectServices");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Services");

            migrationBuilder.RenameTable(
                name: "ProjectServices",
                newName: "ProjectServiceEntity");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectServices_ServiceId",
                table: "ProjectServiceEntity",
                newName: "IX_ProjectServiceEntity_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectServices_ProjectId",
                table: "ProjectServiceEntity",
                newName: "IX_ProjectServiceEntity_ProjectId");

            migrationBuilder.AlterColumn<int>(
                name: "TotalPrice",
                table: "ProjectServiceEntity",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectServiceEntity",
                table: "ProjectServiceEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectServiceEntity_Projects_ProjectId",
                table: "ProjectServiceEntity",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectServiceEntity_Services_ServiceId",
                table: "ProjectServiceEntity",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
