using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLCC.Data.Migrations
{
    /// <inheritdoc />
    public partial class db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DATE_TIME_KEEP",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TIME_CHECK_IN = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TIME_CHECK_OUT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DATE_TIME_KEEP", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ROLE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nvarchar50 = table.Column<string>(name: "nvarchar(50)", type: "nvarchar(max)", nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FULL_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PHONE_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BIRTH_DAY = table.Column<DateTime>(type: "datetime2", nullable: true),
                    COEFFICIENTS_SALARY = table.Column<double>(type: "float", nullable: true),
                    VACATION_DAY = table.Column<int>(type: "int", nullable: true),
                    NUMBER_OF_DAYS = table.Column<int>(type: "int", nullable: true),
                    SALARY = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HISTORY_TIME_KEEP",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    TIME_TIME_KEEP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DATE_TIME_KEEP = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HISTORY_TIME_KEEP", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HISTORY_TIME_KEEP_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LEAVE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    APPROVE_USER_ID = table.Column<int>(type: "int", nullable: false),
                    REASON = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_FOR_DAY = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LEAVE_TYPE = table.Column<int>(type: "int", nullable: false),
                    LEAVE_FORM = table.Column<int>(type: "int", nullable: false),
                    LEAVE_STATUS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LEAVE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LEAVE_USER_APPROVE_USER_ID",
                        column: x => x.APPROVE_USER_ID,
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LEAVE_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TIME_KEEP",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<int>(type: "int", nullable: true),
                    DATE_TIME_KEEP_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIME_KEEP", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TIME_KEEP_DATE_TIME_KEEP_DATE_TIME_KEEP_ID",
                        column: x => x.DATE_TIME_KEEP_ID,
                        principalTable: "DATE_TIME_KEEP",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TIME_KEEP_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USER",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "USER_ROLE",
                columns: table => new
                {
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    ROLE_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_ROLE", x => new { x.ROLE_ID, x.USER_ID });
                    table.ForeignKey(
                        name: "FK_USER_ROLE_ROLE_ROLE_ID",
                        column: x => x.ROLE_ID,
                        principalTable: "ROLE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USER_ROLE_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HISTORY_TIME_KEEP_USER_ID",
                table: "HISTORY_TIME_KEEP",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LEAVE_APPROVE_USER_ID",
                table: "LEAVE",
                column: "APPROVE_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LEAVE_USER_ID",
                table: "LEAVE",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TIME_KEEP_DATE_TIME_KEEP_ID",
                table: "TIME_KEEP",
                column: "DATE_TIME_KEEP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TIME_KEEP_USER_ID",
                table: "TIME_KEEP",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_ROLE_USER_ID",
                table: "USER_ROLE",
                column: "USER_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HISTORY_TIME_KEEP");

            migrationBuilder.DropTable(
                name: "LEAVE");

            migrationBuilder.DropTable(
                name: "TIME_KEEP");

            migrationBuilder.DropTable(
                name: "USER_ROLE");

            migrationBuilder.DropTable(
                name: "DATE_TIME_KEEP");

            migrationBuilder.DropTable(
                name: "ROLE");

            migrationBuilder.DropTable(
                name: "USER");
        }
    }
}
