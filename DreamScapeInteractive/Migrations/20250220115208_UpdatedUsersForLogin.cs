using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DreamScapeInteractive.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedUsersForLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FailedLoginAttempts",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastFailedLogin",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "LoggedInOnce",
                table: "Users",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Trades",
                keyColumn: "Id",
                keyValue: 1,
                column: "TradeDate",
                value: new DateTime(2025, 2, 20, 12, 52, 7, 244, DateTimeKind.Local).AddTicks(9436));

            migrationBuilder.UpdateData(
                table: "Trades",
                keyColumn: "Id",
                keyValue: 2,
                column: "TradeDate",
                value: new DateTime(2025, 2, 19, 12, 52, 7, 244, DateTimeKind.Local).AddTicks(9504));

            migrationBuilder.UpdateData(
                table: "Trades",
                keyColumn: "Id",
                keyValue: 3,
                column: "TradeDate",
                value: new DateTime(2025, 2, 18, 12, 52, 7, 244, DateTimeKind.Local).AddTicks(9511));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FailedLoginAttempts", "HashedPassword", "LastFailedLogin", "LoggedInOnce" },
                values: new object[] { 0, "9tHXAcK4crmX0cPSmsY209AEFP7xNM5Oa0VtgS9XXhA=:XF2409h/1rrJfCh8sCSAKg==:10000:SHA512", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FailedLoginAttempts", "HashedPassword", "LastFailedLogin", "LoggedInOnce" },
                values: new object[] { 0, "f4V1T5CHRkbIXHgCtcWrv/0rBerWTcjNQ/TPbkPoAzI=:vOl25jQjbdg38wqBFmWqyw==:10000:SHA512", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FailedLoginAttempts", "HashedPassword", "LastFailedLogin", "LoggedInOnce" },
                values: new object[] { 0, "oiEbCTDxir8acyUBeDfxAYK8FRBa0tv1xpDABWZnPqE=:Ydo6z2yICr6FbnKWKQ/rMQ==:10000:SHA512", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FailedLoginAttempts", "HashedPassword", "LastFailedLogin", "LoggedInOnce" },
                values: new object[] { 0, "GVjCY+Bj4qoIJr8T7sEHm8YFrHnhUzh6B39ZbKRDRPA=:EEJsy4M2Aa8YfkVWfFkIHw==:10000:SHA512", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FailedLoginAttempts", "HashedPassword", "LastFailedLogin", "LoggedInOnce" },
                values: new object[] { 0, "4sp6ouk5MXEX5+hLDRp5RocUMkwmm6ste6N9nVR45RE=:v3KCLs9sIoyCFGXlDW7oqA==:10000:SHA512", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FailedLoginAttempts",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastFailedLogin",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LoggedInOnce",
                table: "Users");

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
    }
}
