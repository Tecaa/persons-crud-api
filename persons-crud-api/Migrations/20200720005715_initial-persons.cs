using Microsoft.EntityFrameworkCore.Migrations;

namespace persons_crud_api.Migrations
{
    public partial class initialpersons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "persons");

            migrationBuilder.RenameColumn(
                name: "Vd",
                table: "persons",
                newName: "vd");

            migrationBuilder.RenameColumn(
                name: "Rut",
                table: "persons",
                newName: "rut");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "persons",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "persons",
                newName: "age");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "persons",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "persons",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "persons",
                newName: "last_name");

            migrationBuilder.AddPrimaryKey(
                name: "pk_persons",
                table: "persons",
                column: "id");

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "id", "address", "age", "last_name", "name", "rut", "vd" },
                values: new object[,]
                {
                    { 1, "Augustgrad 4112, Korhal", 42, "Raynor", "Jimmy", 9810616, '2' },
                    { 2, "Talematros 243, Shakuras", 38, "Kerrigan", "Sarah", 11832947, '3' }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_persons",
                table: "persons");

            migrationBuilder.DeleteData(
                table: "persons",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "persons",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "persons",
                newName: "Persons");

            migrationBuilder.RenameColumn(
                name: "vd",
                table: "Persons",
                newName: "Vd");

            migrationBuilder.RenameColumn(
                name: "rut",
                table: "Persons",
                newName: "Rut");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Persons",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "Persons",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Persons",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Persons",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Persons",
                newName: "LastName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");
        }
    }
}
