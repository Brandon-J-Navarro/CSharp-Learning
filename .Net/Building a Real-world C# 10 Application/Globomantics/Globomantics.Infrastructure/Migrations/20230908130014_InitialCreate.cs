﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Globomantics.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Todo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Bug_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bug_AssignedToId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssinedToId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Severity = table.Column<int>(type: "int", nullable: true),
                    AffectedVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AffectedUsers = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Component = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: true),
                    AssignedToId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Todo_Todo_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Todo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Todo_Users_AssignedToId",
                        column: x => x.AssignedToId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Todo_Users_Bug_AssignedToId",
                        column: x => x.Bug_AssignedToId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Todo_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BugId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Todo_BugId",
                        column: x => x.BugId,
                        principalTable: "Todo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_BugId",
                table: "Images",
                column: "BugId");

            migrationBuilder.CreateIndex(
                name: "IX_Todo_AssignedToId",
                table: "Todo",
                column: "AssignedToId");

            migrationBuilder.CreateIndex(
                name: "IX_Todo_Bug_AssignedToId",
                table: "Todo",
                column: "Bug_AssignedToId");

            migrationBuilder.CreateIndex(
                name: "IX_Todo_CreatedById",
                table: "Todo",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Todo_ParentId",
                table: "Todo",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Todo");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
