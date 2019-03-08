using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDesk_Razor.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeskQuote",
                columns: table => new
                {
                    DeskQuoteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeskID = table.Column<int>(nullable: false),
                    CustomerName = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    RushDays = table.Column<int>(nullable: false),
                    QuoteAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeskQuote", x => x.DeskQuoteID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeskQuote");
        }
    }
}
