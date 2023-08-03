# Lab12_AsyncInn

Wireframe:

![Schema](C:\Users\shaun\OneDrive\Documents\GitHub\401\Lab12_AsyncInn\assets\Wireframe.png)

Here is a possible way to reword and restructure the markdown file:

# Async Inn Database Schema

This document describes the database schema for the Async Inn hotel chain. The schema consists of four tables: HotelLocation, Room, Amenity, and RoomAmenity. The tables are related by primary and foreign keys, as well as a joint entity table to represent a many-to-many relationship. The schema also uses an enumeration to define the possible values for the room layout type.

## Tables

### HotelLocation

This table stores the information about each hotel location of the Async Inn chain. The primary key is LocationId, which is a unique identifier for each location. The table also has the following attributes:

- Name: The name of the hotel location.
- City: The city where the hotel location is situated.
- State: The state where the hotel location is situated.
- Address: The street address of the hotel location.
- PhoneNumber: The phone number of the hotel location.

### Room

This table stores the information about each room in each hotel location. The primary key is RoomId, which is a unique identifier for each room. The table also has the following attributes:

- Nickname: A nickname for the room layout, such as "Deluxe Suite" or "Cozy Studio".
- LayoutType: An enumeration that specifies the type of room layout, such as OneBedroom, TwoBedroom, or Studio.
- Price: The price of the room per night in US dollars.
- PetFriendly: A boolean value that indicates whether the room allows pets or not.
- LocationId: A foreign key that references the LocationId attribute in the HotelLocation table. This attribute links each room to a specific hotel location.

### Amenity

This table stores the information about each amenity that can be offered by the hotel rooms. The primary key is AmenityId, which is a unique identifier for each amenity. The table only has one attribute:

- Name: The name of the amenity, such as "Wi-Fi" or "Mini Fridge".

### RoomAmenity

This table serves as a joint entity table to establish a many-to-many relationship between the Room and Amenity tables. The primary key is a composite key consisting of RoomId and AmenityId, which uniquely identifies each record in the table. The table also has one attribute:

- Description: A description of the amenity in relation to the room, such as "Free Wi-Fi access" or "Mini Fridge with complimentary drinks".

## Enumerations

### LayoutType

This enumeration defines the possible values for the LayoutType attribute in the Room table. The values are:

- OneBedroom: A room with one bedroom and a separate living area.
- TwoBedroom: A room with two bedrooms and a separate living area.
- Studio: A room with a combined bedroom and living area.

## Relationships

The tables are related by primary and foreign keys, as well as a joint entity table. The relationships are:

- HotelLocation (1) to Room (Many): Each hotel location can have multiple rooms, but each room belongs to only one location. This is a one-to-many relationship, which is represented by the LocationId foreign key in the Room table.
- Room (Many) to Amenity (Many): Each room can have multiple amenities, and each amenity can be associated with multiple rooms. This is a many-to-many relationship, which is represented by the RoomAmenity joint entity table.


##### Assissted by CHATGPT
