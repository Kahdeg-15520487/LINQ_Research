using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestLinq.Migrations
{
    public partial class add_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("8ad3aefb-5e3b-41ee-8db1-a430bf4fd7ab"), "batan" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[] { new Guid("86ad4948-9b38-44d9-9e3a-605d53eb7235"), "batanvlog", new Guid("8ad3aefb-5e3b-41ee-8db1-a430bf4fd7ab") });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "BlogId", "Content", "Name" },
                values: new object[] { new Guid("3767d7ba-431f-458a-9a59-06f0d614c36b"), new Guid("86ad4948-9b38-44d9-9e3a-605d53eb7235"), "Cac chau oi ...", "100 canh ga chien nuoc mam" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("3767d7ba-431f-458a-9a59-06f0d614c36b"));

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: new Guid("86ad4948-9b38-44d9-9e3a-605d53eb7235"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8ad3aefb-5e3b-41ee-8db1-a430bf4fd7ab"));
        }
    }
}
