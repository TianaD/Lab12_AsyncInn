using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab12_AsyncInn.Migrations
{
    /// <inheritdoc />
    public partial class Addtional_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Room_Amenity",
                table: "Room_Amenity");

            migrationBuilder.RenameTable(
                name: "Room_Amenity",
                newName: "RoomAmenity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomAmenity",
                table: "RoomAmenity",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_Room_HotelID",
                table: "Hotel_Room",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_Room_RoomID",
                table: "Hotel_Room",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenity_AmenityID",
                table: "RoomAmenity",
                column: "AmenityID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenity_RoomID",
                table: "RoomAmenity",
                column: "RoomID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_Room_Hotel_HotelID",
                table: "Hotel_Room",
                column: "HotelID",
                principalTable: "Hotel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_Room_Room_RoomID",
                table: "Hotel_Room",
                column: "RoomID",
                principalTable: "Room",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenity_Amenity_AmenityID",
                table: "RoomAmenity",
                column: "AmenityID",
                principalTable: "Amenity",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenity_Room_RoomID",
                table: "RoomAmenity",
                column: "RoomID",
                principalTable: "Room",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_Room_Hotel_HotelID",
                table: "Hotel_Room");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_Room_Room_RoomID",
                table: "Hotel_Room");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenity_Amenity_AmenityID",
                table: "RoomAmenity");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenity_Room_RoomID",
                table: "RoomAmenity");

            migrationBuilder.DropIndex(
                name: "IX_Hotel_Room_HotelID",
                table: "Hotel_Room");

            migrationBuilder.DropIndex(
                name: "IX_Hotel_Room_RoomID",
                table: "Hotel_Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomAmenity",
                table: "RoomAmenity");

            migrationBuilder.DropIndex(
                name: "IX_RoomAmenity_AmenityID",
                table: "RoomAmenity");

            migrationBuilder.DropIndex(
                name: "IX_RoomAmenity_RoomID",
                table: "RoomAmenity");

            migrationBuilder.RenameTable(
                name: "RoomAmenity",
                newName: "Room_Amenity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room_Amenity",
                table: "Room_Amenity",
                column: "ID");
        }
    }
}
