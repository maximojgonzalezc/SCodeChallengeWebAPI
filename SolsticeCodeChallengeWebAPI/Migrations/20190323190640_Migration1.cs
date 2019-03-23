using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolsticeCodeChallengeWebAPI.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Company = table.Column<string>(nullable: false),
                    ProfileImageURL = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    ContactPhone_ContactPhoneid = table.Column<long>(nullable: false),
                    ContactPhone_PersonalPhone = table.Column<string>(nullable: false),
                    ContactPhone_WorkPhone = table.Column<string>(nullable: true),
                    Address_AddressLine1 = table.Column<string>(nullable: true),
                    Address_AddressLine2 = table.Column<string>(nullable: true),
                    Address_City = table.Column<string>(nullable: false),
                    Address_State = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
