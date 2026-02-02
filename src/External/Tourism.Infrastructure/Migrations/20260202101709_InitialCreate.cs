using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tourism.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TouristAttractions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UF = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristAttractions", x => x.Id);
                });

            migrationBuilder.Sql(@"
                CREATE PROCEDURE PRC_Tourist_Attraction_Create
                    @Id UNIQUEIDENTIFIER,
                    @Title NVARCHAR(100),
                    @City NVARCHAR(100),
                    @UF NVARCHAR(2),
                    @Reference NVARCHAR(100),
                    @Description NVARCHAR(100)
                AS
                BEGIN
                    SET NOCOUNT ON;

                    INSERT INTO TouristAttractions
                    (
                        Id,
                        Title,
                        City,
                        UF,
                        Reference,
                        Description,
                        CreatedAt,
                        UpdatedAt
                    )
                    VALUES
                    (
                        @Id,
                        @Title,
                        @City,
                        @UF,
                        @Reference,
                        @Description,
                        SYSUTCDATETIME(),
                        NULL
                    );
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE IF EXISTS PRC_Tourist_Attraction_Create");
            
            migrationBuilder.DropTable(
                name: "TouristAttractions");
        }
    }
}
