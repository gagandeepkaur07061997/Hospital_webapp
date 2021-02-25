using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital_webapp.Migrations
{
    public partial class Hospital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companydetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companydetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recieverdetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile_Number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recieverdetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Senderdetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile_Number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Senderdetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parcel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Delivery_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parcel_weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shipping_cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SenderdetailsId = table.Column<int>(type: "int", nullable: false),
                    CompanydetailsId = table.Column<int>(type: "int", nullable: false),
                    RecieverdetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcel_Companydetails_CompanydetailsId",
                        column: x => x.CompanydetailsId,
                        principalTable: "Companydetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcel_Recieverdetails_RecieverdetailsId",
                        column: x => x.RecieverdetailsId,
                        principalTable: "Recieverdetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcel_Senderdetails_SenderdetailsId",
                        column: x => x.SenderdetailsId,
                        principalTable: "Senderdetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tracking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Expected_date_of_delivery = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParcelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tracking_Parcel_ParcelId",
                        column: x => x.ParcelId,
                        principalTable: "Parcel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_CompanydetailsId",
                table: "Parcel",
                column: "CompanydetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_RecieverdetailsId",
                table: "Parcel",
                column: "RecieverdetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_SenderdetailsId",
                table: "Parcel",
                column: "SenderdetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracking_ParcelId",
                table: "Tracking",
                column: "ParcelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tracking");

            migrationBuilder.DropTable(
                name: "Parcel");

            migrationBuilder.DropTable(
                name: "Companydetails");

            migrationBuilder.DropTable(
                name: "Recieverdetails");

            migrationBuilder.DropTable(
                name: "Senderdetails");
        }
    }
}
