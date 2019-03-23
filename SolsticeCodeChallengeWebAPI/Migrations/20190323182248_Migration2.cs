using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolsticeCodeChallengeWebAPI.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactAddress");

            migrationBuilder.DropTable(
                name: "ContactPhones");

            migrationBuilder.AddColumn<string>(
                name: "Address_AddressLine1",
                table: "Contacts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_AddressLine2",
                table: "Contacts",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Address_AddresssContactForeignKey",
                table: "Contacts",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Contacts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_State",
                table: "Contacts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "ContactPhone_ContactPhoneid",
                table: "Contacts",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ContactPhone_ContactPhonesContactForeignKey",
                table: "Contacts",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "ContactPhone_PersonalPhone",
                table: "Contacts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactPhone_WorkPhone",
                table: "Contacts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_AddressLine1",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Address_AddressLine2",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Address_AddresssContactForeignKey",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Address_State",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactPhone_ContactPhoneid",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactPhone_ContactPhonesContactForeignKey",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactPhone_PersonalPhone",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactPhone_WorkPhone",
                table: "Contacts");

            migrationBuilder.CreateTable(
                name: "ContactAddress",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    AddresssContactForeignKey = table.Column<long>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true)
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
                    ContactPhonesContactForeignKey = table.Column<long>(nullable: false),
                    PersonalPhone = table.Column<string>(nullable: true),
                    WorkPhone = table.Column<string>(nullable: true)
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
    }
}
