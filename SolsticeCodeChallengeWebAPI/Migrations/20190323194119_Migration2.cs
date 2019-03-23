using Microsoft.EntityFrameworkCore.Migrations;

namespace SolsticeCodeChallengeWebAPI.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactPhone_WorkPhone",
                table: "Contacts",
                newName: "WorkPhone");

            migrationBuilder.RenameColumn(
                name: "ContactPhone_PersonalPhone",
                table: "Contacts",
                newName: "PersonalPhone");

            migrationBuilder.RenameColumn(
                name: "Address_State",
                table: "Contacts",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "Contacts",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "Address_AddressLine1",
                table: "Contacts",
                newName: "AddressLine1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WorkPhone",
                table: "Contacts",
                newName: "ContactPhone_WorkPhone");

            migrationBuilder.RenameColumn(
                name: "PersonalPhone",
                table: "Contacts",
                newName: "ContactPhone_PersonalPhone");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Contacts",
                newName: "Address_State");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Contacts",
                newName: "Address_City");

            migrationBuilder.RenameColumn(
                name: "AddressLine1",
                table: "Contacts",
                newName: "Address_AddressLine1");
        }
    }
}
