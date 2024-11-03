using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticApp.Migrations
{
    /// <inheritdoc />
    public partial class Database_v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_RecipientAddressId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_SenderAdressId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Streets_StreetType_street_type_id",
                table: "Streets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StreetType",
                table: "StreetType");

            migrationBuilder.RenameTable(
                name: "StreetType",
                newName: "StreetTypes");

            migrationBuilder.RenameColumn(
                name: "RecipientAddressId",
                table: "Orders",
                newName: "recipient_address_id");

            migrationBuilder.RenameColumn(
                name: "SenderAdressId",
                table: "Orders",
                newName: "sender_address_id");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_SenderAdressId",
                table: "Orders",
                newName: "IX_Orders_sender_address_id");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_RecipientAddressId",
                table: "Orders",
                newName: "IX_Orders_recipient_address_id");

            migrationBuilder.RenameColumn(
                name: "steet_type_id",
                table: "StreetTypes",
                newName: "street_type_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StreetTypes",
                table: "StreetTypes",
                column: "street_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_recipient_address_id",
                table: "Orders",
                column: "recipient_address_id",
                principalTable: "Addresses",
                principalColumn: "address_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_sender_address_id",
                table: "Orders",
                column: "sender_address_id",
                principalTable: "Addresses",
                principalColumn: "address_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Streets_StreetTypes_street_type_id",
                table: "Streets",
                column: "street_type_id",
                principalTable: "StreetTypes",
                principalColumn: "street_type_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_recipient_address_id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_sender_address_id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Streets_StreetTypes_street_type_id",
                table: "Streets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StreetTypes",
                table: "StreetTypes");

            migrationBuilder.RenameTable(
                name: "StreetTypes",
                newName: "StreetType");

            migrationBuilder.RenameColumn(
                name: "recipient_address_id",
                table: "Orders",
                newName: "RecipientAddressId");

            migrationBuilder.RenameColumn(
                name: "sender_address_id",
                table: "Orders",
                newName: "SenderAdressId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_sender_address_id",
                table: "Orders",
                newName: "IX_Orders_SenderAdressId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_recipient_address_id",
                table: "Orders",
                newName: "IX_Orders_RecipientAddressId");

            migrationBuilder.RenameColumn(
                name: "street_type_id",
                table: "StreetType",
                newName: "steet_type_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StreetType",
                table: "StreetType",
                column: "steet_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_RecipientAddressId",
                table: "Orders",
                column: "RecipientAddressId",
                principalTable: "Addresses",
                principalColumn: "address_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_SenderAdressId",
                table: "Orders",
                column: "SenderAdressId",
                principalTable: "Addresses",
                principalColumn: "address_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Streets_StreetType_street_type_id",
                table: "Streets",
                column: "street_type_id",
                principalTable: "StreetType",
                principalColumn: "steet_type_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
