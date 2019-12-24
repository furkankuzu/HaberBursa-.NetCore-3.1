using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HaberBursa.Data.Migrations
{
    public partial class AddTablesFirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Writer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: false),
                    EMail = table.Column<string>(nullable: false),
                    Info = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    CountryID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Writer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Writer_Country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Headline = table.Column<string>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true),
                    Explanation = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Video = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    WriterID = table.Column<int>(nullable: true),
                    CountryID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.ID);
                    table.ForeignKey(
                        name: "FK_News_Country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_News_Writer_WriterID",
                        column: x => x.WriterID,
                        principalTable: "Writer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Context = table.Column<string>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    NewsID = table.Column<int>(nullable: true),
                    WriterID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comment_News_NewsID",
                        column: x => x.NewsID,
                        principalTable: "News",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_Writer_WriterID",
                        column: x => x.WriterID,
                        principalTable: "Writer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_NewsID",
                table: "Comment",
                column: "NewsID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_WriterID",
                table: "Comment",
                column: "WriterID");

            migrationBuilder.CreateIndex(
                name: "IX_News_CountryID",
                table: "News",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_News_WriterID",
                table: "News",
                column: "WriterID");

            migrationBuilder.CreateIndex(
                name: "IX_Writer_CountryID",
                table: "Writer",
                column: "CountryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Writer");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
