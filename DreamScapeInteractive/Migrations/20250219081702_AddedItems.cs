using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DreamScapeInteractive.Migrations
{
    /// <inheritdoc />
    public partial class AddedItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "Durability", "MagicPropertyId", "Name", "Power", "Rarity", "Speed", "TypeId" },
                values: new object[,]
                {
                    { 11, "Flames dance along its edge without heat", 95, 2, "Blazing Claymore of Ruin", 80, 73, 15, 1 },
                    { 12, "Its venomous edge never dulls", 85, 8, "Venomfang Dirk", 45, 55, 60, 2 },
                    { 13, "Dark mist trails its tip", 40, 1, "Wand of Lurking Shadows", 50, 78, 10, 3 },
                    { 14, "Thunder rumbles when struck", 130, 3, "Aegis of the Stormborn", 15, 92, -3, 4 },
                    { 15, "Faint lunar glow when worn", 48, 5, "Ring of the Moonlit Veil", 25, 99, 18, 5 },
                    { 16, "Arrows vanish into mist upon release", 70, 7, "Phantom Recurve", 55, 82, 45, 6 },
                    { 17, "Hums with cosmic energy", 50, 6, "Celestial Talisman", 30, 89, 15, 7 },
                    { 18, "Every step leaves a wisp of wind", 55, 4, "Greaves of the Gale", 10, 60, 65, 8 },
                    { 19, "Visions of past and future haunt the wearer", 75, 3, "Crown of the Dreamwalker", 20, 88, 5, 9 },
                    { 20, "Ink moves across the pages on its own", 35, 11, "Grimoire of Forgotten Secrets", 70, 100, 2, 10 },
                    { 21, "Its blade burns with an eternal golden flame.", 95, 10, "Greatsword of the Blazing Sun", 60, 82, 12, 1 },
                    { 22, "A faint green liquid drips from its serrated edge.", 78, 3, "Venomfang Dagger", 28, 72, 40, 2 },
                    { 23, "Glowing runes shift and rearrange on its surface.", 68, 7, "Runed Staff of the Arcane Flow", 52, 88, 7, 3 },
                    { 24, "Electricity arcs between the engraved symbols.", 110, 5, "Aegis of the Stormcaller", 15, 80, -3, 4 },
                    { 25, "Its dark gemstone absorbs the light around it.", 55, 9, "Eclipse Ring", 18, 90, 22, 5 },
                    { 26, "The arrows fired vanish mid-flight before striking.", 62, 6, "Phantom Longbow", 35, 75, 38, 6 },
                    { 27, "A soft hum emanates from the crystal centerpiece.", 42, 8, "Celestial Amulet", 22, 95, 12, 7 },
                    { 28, "A rush of wind follows your every step.", 48, 4, "Skystrider Boots", 6, 60, 55, 8 },
                    { 29, "It pulses with visions from unseen realms.", 87, 2, "Crown of the Dreamwalker", 10, 78, 5, 9 },
                    { 30, "Its pages whisper secrets in a long-dead tongue.", 35, 11, "Grimoire of Forgotten Truths", 70, 100, 0, 10 }
                });

            migrationBuilder.UpdateData(
                table: "Trades",
                keyColumn: "Id",
                keyValue: 1,
                column: "TradeDate",
                value: new DateTime(2025, 2, 19, 9, 17, 2, 351, DateTimeKind.Local).AddTicks(1473));

            migrationBuilder.UpdateData(
                table: "Trades",
                keyColumn: "Id",
                keyValue: 2,
                column: "TradeDate",
                value: new DateTime(2025, 2, 18, 9, 17, 2, 351, DateTimeKind.Local).AddTicks(1524));

            migrationBuilder.UpdateData(
                table: "Trades",
                keyColumn: "Id",
                keyValue: 3,
                column: "TradeDate",
                value: new DateTime(2025, 2, 17, 9, 17, 2, 351, DateTimeKind.Local).AddTicks(1529));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "HashedPassword",
                value: "6+1jyK1OnBX5LWVi8FKpEN7HWkJC2AzEKgPjGTM7Hlg=:vowv/9+PvP0h8BxqngS+Lw==:10000:SHA512");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "HashedPassword",
                value: "OpBOFsYfalEz6nIzVIiaWG92UaFvtgBRn3r+i5uv47E=:lEeOqVCpKOUbY41k6hi+Sg==:10000:SHA512");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "HashedPassword",
                value: "wFPtqYiPv/A876oc98veJGzxXckz8eVSEf/vJQ0rWyk=:6j6x+XbOSRaMwxn+LX4f+w==:10000:SHA512");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "HashedPassword",
                value: "T33HJyinuc+bobjgnJZL15gy5RYoWI4776tyLWOQbUw=:+4R7Zfhc+rsBs+x2KDzcaw==:10000:SHA512");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "HashedPassword",
                value: "z0KrOptMN0akR4yh1D/JrS/AwX4POyji9O59sUDzvJM=:/fat5afj4pNflbjamPoyig==:10000:SHA512");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.UpdateData(
                table: "Trades",
                keyColumn: "Id",
                keyValue: 1,
                column: "TradeDate",
                value: new DateTime(2025, 2, 18, 13, 22, 43, 122, DateTimeKind.Local).AddTicks(6869));

            migrationBuilder.UpdateData(
                table: "Trades",
                keyColumn: "Id",
                keyValue: 2,
                column: "TradeDate",
                value: new DateTime(2025, 2, 17, 13, 22, 43, 122, DateTimeKind.Local).AddTicks(6929));

            migrationBuilder.UpdateData(
                table: "Trades",
                keyColumn: "Id",
                keyValue: 3,
                column: "TradeDate",
                value: new DateTime(2025, 2, 16, 13, 22, 43, 122, DateTimeKind.Local).AddTicks(6934));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "HashedPassword",
                value: "x23QkAqeU+9b0ybcjfg3h2ScmMSAc1DTBuC+WE2XQC0=:bbjEEquFZMHKfIIQ+cvK2g==:10000:SHA512");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "HashedPassword",
                value: "LrU9t6phK7+r7ihcWD36kaiWN6EFP4vx4DAbu9Bk5Bs=:jLLnmlBpK+O9l71RQo/3lw==:10000:SHA512");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "HashedPassword",
                value: "3uhLhDIwMQUDpsGS6oLCp3BRdBIpRh8/Z3P+L+gSXyU=:kMEEhG9pd+96x11u/vik2Q==:10000:SHA512");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "HashedPassword",
                value: "yogKZUvtDr+1O24cCnCZaHGXKg5MNSDVUMYuhnG7dKg=:qwmS/3Y2Y5JVg1FinophPA==:10000:SHA512");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "HashedPassword",
                value: "Mu9y5nh4s5wg2TflHgmdElfebIXhWPXUvvkaU0jBlD8=:yjdmG3cnskOMw0TGwprilg==:10000:SHA512");
        }
    }
}
