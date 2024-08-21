using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_project.Migrations
{
    public partial class SettingandSubscribeTablesCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarImages_Categories_CategoryId",
                table: "CarImages");

            migrationBuilder.DropIndex(
                name: "IX_CarImages_CategoryId",
                table: "CarImages");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AddressTitle",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "CallUs",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "CallUsNumber",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "CarImages");

            migrationBuilder.RenameColumn(
                name: "ImageLogo",
                table: "Settings",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "EmailTitle",
                table: "Settings",
                newName: "Key");

            migrationBuilder.CreateTable(
                name: "Subscribers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriberEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscribers");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Settings",
                newName: "ImageLogo");

            migrationBuilder.RenameColumn(
                name: "Key",
                table: "Settings",
                newName: "EmailTitle");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddressTitle",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CallUs",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CallUsNumber",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "CarImages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarImages_CategoryId",
                table: "CarImages",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarImages_Categories_CategoryId",
                table: "CarImages",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
