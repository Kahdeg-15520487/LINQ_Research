using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestLinq.Migrations
{
    public partial class add_id_generator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Users",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Posts",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Blogs",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Users",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Blogs",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "NEWID()");
        }
    }
}
