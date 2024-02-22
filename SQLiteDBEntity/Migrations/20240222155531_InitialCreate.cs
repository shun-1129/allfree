using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SQLiteDBEntity.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "m_sex",
                columns: table => new
                {
                    m_sex_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    m_sex_name = table.Column<string>(type: "TEXT", nullable: false),
                    is_deleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    create_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    create_user = table.Column<string>(type: "TEXT", nullable: false),
                    create_program = table.Column<string>(type: "TEXT", nullable: false),
                    update_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    update_user = table.Column<string>(type: "TEXT", nullable: false),
                    update_program = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("m_sex_PKC", x => x.m_sex_id);
                });

            migrationBuilder.CreateTable(
                name: "s_master_edit_password",
                columns: table => new
                {
                    system_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    create_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    create_user = table.Column<string>(type: "TEXT", nullable: false),
                    create_program = table.Column<string>(type: "TEXT", nullable: false),
                    update_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    update_user = table.Column<string>(type: "TEXT", nullable: false),
                    update_program = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("s_master_edit_password_PKC", x => x.system_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "m_sex");

            migrationBuilder.DropTable(
                name: "s_master_edit_password");
        }
    }
}
