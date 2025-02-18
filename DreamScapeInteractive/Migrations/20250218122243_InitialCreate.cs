using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DreamScapeInteractive.Migrations
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
                name: "ItemTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MagicProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicProperties", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmailAddress = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Username = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HashedPassword = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsAdmin = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Rarity = table.Column<int>(type: "int", nullable: false),
                    Power = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    Durability = table.Column<int>(type: "int", nullable: false),
                    MagicPropertyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_ItemTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_MagicProperties_MagicPropertyId",
                        column: x => x.MagicPropertyId,
                        principalTable: "MagicProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserItems",
                columns: table => new
                {
                    UserItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserItems", x => x.UserItemId);
                    table.ForeignKey(
                        name: "FK_UserItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Trades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserItem1Id = table.Column<int>(type: "int", nullable: false),
                    UserItem2Id = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TradeDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trades_UserItems_UserItem1Id",
                        column: x => x.UserItem1Id,
                        principalTable: "UserItems",
                        principalColumn: "UserItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trades_UserItems_UserItem2Id",
                        column: x => x.UserItem2Id,
                        principalTable: "UserItems",
                        principalColumn: "UserItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trades_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "ItemTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sword" },
                    { 2, "Dagger" },
                    { 3, "Staff" },
                    { 4, "Shield" },
                    { 5, "Ring" },
                    { 6, "Bow" },
                    { 7, "Amulet" },
                    { 8, "Boots" },
                    { 9, "Helmet" },
                    { 10, "Tome" }
                });

            migrationBuilder.InsertData(
                table: "MagicProperties",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[,]
                {
                    { 1, "Flame Enchantment", 3 },
                    { 2, "Frostbite Aura", 4 },
                    { 3, "Storm Surge", 5 },
                    { 4, "Windwalker’s Grace", 2 },
                    { 5, "Stoneheart Barrier", 3 },
                    { 6, "Shadow Cloak", 4 },
                    { 7, "Venomous Touch", 3 },
                    { 8, "Radiant Blessing", 5 },
                    { 9, "Timewarp Echo", 5 },
                    { 10, "Abyssal Curse", 6 },
                    { 11, "Abyssal Curses", 8 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmailAddress", "HashedPassword", "IsAdmin", "Username" },
                values: new object[,]
                {
                    { 1, "seeker@dreamscape.com", "x23QkAqeU+9b0ybcjfg3h2ScmMSAc1DTBuC+WE2XQC0=:bbjEEquFZMHKfIIQ+cvK2g==:10000:SHA512", true, "DreamSeeker" },
                    { 2, "wanderer@dreamscape.com", "LrU9t6phK7+r7ihcWD36kaiWN6EFP4vx4DAbu9Bk5Bs=:jLLnmlBpK+O9l71RQo/3lw==:10000:SHA512", false, "StarWanderer" },
                    { 3, "guardian@dreamscape.com", "3uhLhDIwMQUDpsGS6oLCp3BRdBIpRh8/Z3P+L+gSXyU=:kMEEhG9pd+96x11u/vik2Q==:10000:SHA512", false, "MysticGuardian" },
                    { 4, "walker@dreamscape.com", "yogKZUvtDr+1O24cCnCZaHGXKg5MNSDVUMYuhnG7dKg=:qwmS/3Y2Y5JVg1FinophPA==:10000:SHA512", false, "ShadowWalker" },
                    { 5, "luna@dreamscape.com", "Mu9y5nh4s5wg2TflHgmdElfebIXhWPXUvvkaU0jBlD8=:yjdmG3cnskOMw0TGwprilg==:10000:SHA512", false, "LunaCaller" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "Durability", "MagicPropertyId", "Name", "Power", "Rarity", "Speed", "TypeId" },
                values: new object[,]
                {
                    { 1, "It feels weirdly cool to the touch", 99, 10, "Burning Sword of Damnation", 40, 50, 10, 1 },
                    { 2, "Its blade glistens with eternal frost", 80, 7, "Frozen Dagger of the North", 25, 60, 35, 2 },
                    { 3, "It radiates warmth and whispers of ancient knowledge", 70, 3, "Staff of the Eternal Sun", 55, 90, 5, 3 },
                    { 4, "Its surface reflects the memories of fallen heroes", 120, 5, "Shield of the Forgotten King", 10, 75, -5, 4 },
                    { 5, "Wearing it feels like slipping into the darkness itself", 50, 9, "Ring of Shadows", 15, 85, 20, 5 },
                    { 6, "The bowstring hums with a mournful song", 60, 11, "Cursed Bow of the Phantom", 30, 65, 40, 6 },
                    { 7, "Its gem pulses with the energy of distant stars", 40, 6, "Amulet of the Starcaller", 20, 95, 10, 7 },
                    { 8, "You feel lighter just by wearing them", 45, 4, "Boots of the Windwalker", 5, 55, 50, 8 },
                    { 9, "Whispers of ancient minds fill your ears", 85, 6, "Helmet of Echoing Thoughts", 8, 70, 2, 9 },
                    { 10, "The pages are blank, but you hear them screaming", 30, 10, "Tome of the Abyss", 65, 100, 0, 10 }
                });

            migrationBuilder.InsertData(
                table: "UserItems",
                columns: new[] { "UserItemId", "ItemId", "Quantity", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 20, 1 },
                    { 2, 2, 10, 2 },
                    { 3, 3, 5, 3 },
                    { 4, 4, 15, 4 },
                    { 5, 5, 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "Id", "Status", "TradeDate", "UserId", "UserItem1Id", "UserItem2Id" },
                values: new object[,]
                {
                    { 1, "Pending", new DateTime(2025, 2, 18, 13, 22, 43, 122, DateTimeKind.Local).AddTicks(6869), null, 1, 2 },
                    { 2, "Completed", new DateTime(2025, 2, 17, 13, 22, 43, 122, DateTimeKind.Local).AddTicks(6929), null, 2, 3 },
                    { 3, "Cancelled", new DateTime(2025, 2, 16, 13, 22, 43, 122, DateTimeKind.Local).AddTicks(6934), null, 4, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_MagicPropertyId",
                table: "Items",
                column: "MagicPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_TypeId",
                table: "Items",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_UserId",
                table: "Trades",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_UserItem1Id",
                table: "Trades",
                column: "UserItem1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_UserItem2Id",
                table: "Trades",
                column: "UserItem2Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserItems_ItemId",
                table: "UserItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_UserItems_UserId",
                table: "UserItems",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trades");

            migrationBuilder.DropTable(
                name: "UserItems");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ItemTypes");

            migrationBuilder.DropTable(
                name: "MagicProperties");
        }
    }
}
