using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharp_App.Migrations
{
    /// <inheritdoc />
    public partial class bdOracle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_PRODUCT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    name = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    category = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    price = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    created_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    shelf_id = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_PRODUCT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_SHELF",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    shelf_hall = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_SHELF", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_PRODUCT");

            migrationBuilder.DropTable(
                name: "T_SHELF");
        }
    }
}
