using System;
using System.Text;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestLinq.Migrations
{
    public partial class add_stored_procedure_GetUserById : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string storedProcedureCode =
            @"
            CREATE PROCEDURE dbo.GetUserById @id nvarchar(36)
            AS
            BEGIN
            SELECT * FROM dbo.Users WHERE Id = @id
            END
            ";


            migrationBuilder.Sql(storedProcedureCode);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE dbo.GetUserById");
        }
    }
}
