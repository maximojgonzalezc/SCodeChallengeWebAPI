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
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactAddress",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    AddresssContactForeignKey = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactAddress", x => x.id);
                    table.ForeignKey(
                        name: "FK_ContactAddress_Contacts_AddresssContactForeignKey",
                        column: x => x.AddresssContactForeignKey,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactPhones",
                columns: table => new
                {
                    ContactPhoneid = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonalPhone = table.Column<string>(nullable: true),
                    WorkPhone = table.Column<string>(nullable: true),
                    ContactPhonesContactForeignKey = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPhones", x => x.ContactPhoneid);
                    table.ForeignKey(
                        name: "FK_ContactPhones_Contacts_ContactPhonesContactForeignKey",
                        column: x => x.ContactPhonesContactForeignKey,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactAddress_AddresssContactForeignKey",
                table: "ContactAddress",
                column: "AddresssContactForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactPhones_ContactPhonesContactForeignKey",
                table: "ContactPhones",
                column: "ContactPhonesContactForeignKey",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactAddress");

            migrationBuilder.DropTable(
                name: "ContactPhones");

            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
