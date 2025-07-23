using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.Migrations
{
    public partial class Identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Step 1: Add a new column with IDENTITY
            migrationBuilder.AddColumn<int>(
                name: "NewId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            // Step 2: Drop old primary key
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            // Step 3: Drop old Id column
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Employees");

            // Step 4: Rename NewId to Id
            migrationBuilder.RenameColumn(
                name: "NewId",
                table: "Employees",
                newName: "Id");

            // Step 5: Re-add primary key on the new Id column
            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Step 1: Drop primary key on new Id
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            // Step 2: Rename Id back to NewId
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employees",
                newName: "NewId");

            // Step 3: Add original Id column back (not identity)
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            // Step 4: Drop the NewId column
            migrationBuilder.DropColumn(
                name: "NewId",
                table: "Employees");

            // Step 5: Re-add primary key on old Id
            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");
        }
    }
}
