using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace grace.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("role_pk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "service",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying", nullable: false),
                    code = table.Column<string>(type: "character varying", nullable: true),
                    costperhour = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("service_pk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "status",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("status_pk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: false),
                    surname = table.Column<string>(type: "character varying", nullable: false),
                    patronimic = table.Column<string>(type: "character varying", nullable: true),
                    code = table.Column<int>(type: "integer", nullable: false),
                    pasportseries = table.Column<int>(type: "integer", nullable: true),
                    pasportnumber = table.Column<int>(type: "integer", nullable: true),
                    birthday = table.Column<DateOnly>(type: "date", nullable: true),
                    address = table.Column<string>(type: "character varying", nullable: true),
                    email = table.Column<string>(type: "character varying", nullable: false),
                    password = table.Column<string>(type: "character varying", nullable: false),
                    roleid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_pk", x => x.id);
                    table.ForeignKey(
                        name: "user_role_fk",
                        column: x => x.roleid,
                        principalTable: "role",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    startdate = table.Column<DateOnly>(type: "date", nullable: false),
                    starttime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    statusid = table.Column<int>(type: "integer", nullable: false),
                    enddate = table.Column<DateOnly>(type: "date", nullable: true),
                    durationinminutes = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("order_pk", x => x.id);
                    table.ForeignKey(
                        name: "order_status_fk",
                        column: x => x.statusid,
                        principalTable: "status",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "order_user_fk",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "orderservice",
                columns: table => new
                {
                    orderid = table.Column<int>(type: "integer", nullable: false),
                    serviceid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "orderservice_order_fk",
                        column: x => x.orderid,
                        principalTable: "order",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "orderservice_service_fk",
                        column: x => x.serviceid,
                        principalTable: "service",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_order_statusid",
                table: "order",
                column: "statusid");

            migrationBuilder.CreateIndex(
                name: "IX_order_userid",
                table: "order",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_orderservice_orderid",
                table: "orderservice",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "IX_orderservice_serviceid",
                table: "orderservice",
                column: "serviceid");

            migrationBuilder.CreateIndex(
                name: "IX_user_roleid",
                table: "user",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "user_unique",
                table: "user",
                column: "code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderservice");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "service");

            migrationBuilder.DropTable(
                name: "status");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "role");
        }
    }
}
