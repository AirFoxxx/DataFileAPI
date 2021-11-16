using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeInBytes = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataFiles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataFiles");
        }
    }
}
