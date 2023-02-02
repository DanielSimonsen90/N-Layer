using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddBossRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Users_BossId1",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_BossId1",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "BossId1",
                table: "Departments");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_BossId",
                table: "Departments",
                column: "BossId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_BossId",
                table: "Departments",
                column: "BossId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Users_BossId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_BossId",
                table: "Departments");

            migrationBuilder.AddColumn<int>(
                name: "BossId1",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_BossId1",
                table: "Departments",
                column: "BossId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_BossId1",
                table: "Departments",
                column: "BossId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
