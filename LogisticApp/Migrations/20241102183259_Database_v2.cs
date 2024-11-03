using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticApp.Migrations
{
    /// <inheritdoc />
    public partial class Database_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Cities_CityId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Houses_HouseId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Streets_StreetId",
                table: "Addresses");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropColumn(
                name: "order_unique_number",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "StreetId",
                table: "Addresses",
                newName: "street_id");

            migrationBuilder.RenameColumn(
                name: "HouseId",
                table: "Addresses",
                newName: "house_id");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Addresses",
                newName: "city_id");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_StreetId",
                table: "Addresses",
                newName: "IX_Addresses_street_id");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_HouseId",
                table: "Addresses",
                newName: "IX_Addresses_house_id");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                newName: "IX_Addresses_city_id");

            migrationBuilder.AddColumn<Guid>(
                name: "street_type_id",
                table: "Streets",
                type: "binary(16)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "order_display_id",
                table: "Orders",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "postcode_id",
                table: "Houses",
                type: "binary(16)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Postcodes",
                columns: table => new
                {
                    postcode_id = table.Column<Guid>(type: "binary(16)", nullable: false),
                    code = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postcodes", x => x.postcode_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StreetType",
                columns: table => new
                {
                    steet_type_id = table.Column<Guid>(type: "binary(16)", nullable: false),
                    street_type_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StreetType", x => x.steet_type_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Streets_street_type_id",
                table: "Streets",
                column: "street_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_postcode_id",
                table: "Houses",
                column: "postcode_id");

            migrationBuilder.CreateIndex(
                name: "IX_Postcodes_code",
                table: "Postcodes",
                column: "code",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Cities_city_id",
                table: "Addresses",
                column: "city_id",
                principalTable: "Cities",
                principalColumn: "city_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Houses_house_id",
                table: "Addresses",
                column: "house_id",
                principalTable: "Houses",
                principalColumn: "house_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Streets_street_id",
                table: "Addresses",
                column: "street_id",
                principalTable: "Streets",
                principalColumn: "street_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_Postcodes_postcode_id",
                table: "Houses",
                column: "postcode_id",
                principalTable: "Postcodes",
                principalColumn: "postcode_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Streets_StreetType_street_type_id",
                table: "Streets",
                column: "street_type_id",
                principalTable: "StreetType",
                principalColumn: "steet_type_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Cities_city_id",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Houses_house_id",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Streets_street_id",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Houses_Postcodes_postcode_id",
                table: "Houses");

            migrationBuilder.DropForeignKey(
                name: "FK_Streets_StreetType_street_type_id",
                table: "Streets");

            migrationBuilder.DropTable(
                name: "Postcodes");

            migrationBuilder.DropTable(
                name: "StreetType");

            migrationBuilder.DropIndex(
                name: "IX_Streets_street_type_id",
                table: "Streets");

            migrationBuilder.DropIndex(
                name: "IX_Houses_postcode_id",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "street_type_id",
                table: "Streets");

            migrationBuilder.DropColumn(
                name: "order_display_id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "postcode_id",
                table: "Houses");

            migrationBuilder.RenameColumn(
                name: "street_id",
                table: "Addresses",
                newName: "StreetId");

            migrationBuilder.RenameColumn(
                name: "house_id",
                table: "Addresses",
                newName: "HouseId");

            migrationBuilder.RenameColumn(
                name: "city_id",
                table: "Addresses",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_street_id",
                table: "Addresses",
                newName: "IX_Addresses_StreetId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_house_id",
                table: "Addresses",
                newName: "IX_Addresses_HouseId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_city_id",
                table: "Addresses",
                newName: "IX_Addresses_CityId");

            migrationBuilder.AddColumn<int>(
                name: "order_unique_number",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    building_id = table.Column<Guid>(type: "binary(16)", nullable: false),
                    house_id = table.Column<Guid>(type: "binary(16)", nullable: false),
                    building_number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.building_id);
                    table.ForeignKey(
                        name: "FK_Buildings_Houses_house_id",
                        column: x => x.house_id,
                        principalTable: "Houses",
                        principalColumn: "house_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_house_id",
                table: "Buildings",
                column: "house_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Cities_CityId",
                table: "Addresses",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "city_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Houses_HouseId",
                table: "Addresses",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "house_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Streets_StreetId",
                table: "Addresses",
                column: "StreetId",
                principalTable: "Streets",
                principalColumn: "street_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
