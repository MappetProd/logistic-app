using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    country_id = table.Column<Guid>(type: "binary(16)", nullable: false),
                    country_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.country_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    city_id = table.Column<Guid>(type: "binary(16)", nullable: false),
                    city_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    country_id = table.Column<Guid>(type: "binary(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.city_id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_country_id",
                        column: x => x.country_id,
                        principalTable: "Countries",
                        principalColumn: "country_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Streets",
                columns: table => new
                {
                    street_id = table.Column<Guid>(type: "binary(16)", nullable: false),
                    street_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    city_id = table.Column<Guid>(type: "binary(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => x.street_id);
                    table.ForeignKey(
                        name: "FK_Streets_Cities_city_id",
                        column: x => x.city_id,
                        principalTable: "Cities",
                        principalColumn: "city_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    house_id = table.Column<Guid>(type: "binary(16)", nullable: false),
                    house_number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    street_id = table.Column<Guid>(type: "binary(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.house_id);
                    table.ForeignKey(
                        name: "FK_Houses_Streets_street_id",
                        column: x => x.street_id,
                        principalTable: "Streets",
                        principalColumn: "street_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    address_id = table.Column<Guid>(type: "binary(16)", nullable: false),
                    CityId = table.Column<Guid>(type: "binary(16)", nullable: false),
                    StreetId = table.Column<Guid>(type: "binary(16)", nullable: false),
                    HouseId = table.Column<Guid>(type: "binary(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.address_id);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "city_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "house_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Streets_StreetId",
                        column: x => x.StreetId,
                        principalTable: "Streets",
                        principalColumn: "street_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    building_id = table.Column<Guid>(type: "binary(16)", nullable: false),
                    building_number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    house_id = table.Column<Guid>(type: "binary(16)", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    order_id = table.Column<Guid>(type: "binary(16)", nullable: false),
                    order_unique_number = table.Column<int>(type: "int", nullable: false),
                    SenderAdressId = table.Column<Guid>(type: "binary(16)", nullable: false),
                    RecipientAddressId = table.Column<Guid>(type: "binary(16)", nullable: false),
                    cargo_weight_in_grams = table.Column<int>(type: "int", nullable: false),
                    order_creation_dtm = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_RecipientAddressId",
                        column: x => x.RecipientAddressId,
                        principalTable: "Addresses",
                        principalColumn: "address_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_SenderAdressId",
                        column: x => x.SenderAdressId,
                        principalTable: "Addresses",
                        principalColumn: "address_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_HouseId",
                table: "Addresses",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StreetId",
                table: "Addresses",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_house_id",
                table: "Buildings",
                column: "house_id");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_country_id",
                table: "Cities",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_street_id",
                table: "Houses",
                column: "street_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RecipientAddressId",
                table: "Orders",
                column: "RecipientAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SenderAdressId",
                table: "Orders",
                column: "SenderAdressId");

            migrationBuilder.CreateIndex(
                name: "IX_Streets_city_id",
                table: "Streets",
                column: "city_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Streets");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
