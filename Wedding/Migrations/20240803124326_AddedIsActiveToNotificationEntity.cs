﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wedding.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsActiveToNotificationEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Notification",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Notification");
        }
    }
}
