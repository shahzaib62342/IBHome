using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IBHome.API.Migrations
{
    /// <inheritdoc />
    public partial class AddUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    IsEmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    UserTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SocialType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocialUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    FollowersCount = table.Column<int>(type: "int", nullable: false),
                    OrdersCount = table.Column<int>(type: "int", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePicUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderCount = table.Column<int>(type: "int", nullable: false),
                    TotalStars = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FCMToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expertise = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Achivements = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAllowLogin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserTypes_UserTypeID",
                        column: x => x.UserTypeID,
                        principalTable: "UserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeID",
                table: "Users",
                column: "UserTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
