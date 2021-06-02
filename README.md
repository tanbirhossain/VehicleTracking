# Vehicle Tracking Api

## General Information

This repository contains `Vehicle Tracking `  where company's employee can reserve room based on there office location , date , timeline and capacity. new system

The process is simplified in this example.  
1.) **Register** a client with first name , last name, email, password .

2.) A registered client can add mutiple vehicle with Name, DeviceId.
Device Id is unique id which you get from the GPS device.


3.) Then create the **Room** and have to metion **Fixed Resources** and **Fix chairs** which are not moveable in the room.  
4.) **Employee** can reserve room based on their location , time , date and meeting participate persons also they can choose moveable resources and extra chairs.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

## Prerequisites

Please make sure you've already installed Visual Studio 2019, .Net Core 3.1 sdk and Sql Server 2019 in your windows 10 platform .

[Visual Studio 2019](https://visualstudio.microsoft.com/downloads/)  
[.Net 5](https://dotnet.microsoft.com/download/dotnet-core/3.1)  
[Sql Server 2019](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installing

A step by step series of examples that tell you have to get a development env running
Clone this repository:

```
git clone https://github.com:tanbirhossain/RoomReservation.git
```

Change directory to `RoomReservation` folder and Open `RoomReservation.sln` With Visual Studio

## Database Config

1. Execute database scripts in your `MSSQL Database` from [SQL Scripts](/Utils/Scripts/script.sql)
2. Change database connection in `appsettings.json` from `RR.WEB` project in the UI folder from visual studio

`ConnectionStrings` section in `appsettings.json`:

```
  "ConnectionStrings": {
    "ReservationDBConnection": "Server=localhost;Database=ReservationDB;user id=sa;password=123456789;"
  },

```

## Build

Select and Run `RR.WEB` application in the UI folder from visual studio
Open Browser with `https://localhost:5001` it will redirect the `User Login Panel`

**User panel:**

URL: `https://localhost:5001/Security/Account/Login`

Amsterdam office User :

```
Username : ovibhuiyan43@hotmail.com
Password : 1234
```

Berlin office User :

```
Username : ovibhuiyan43@gmail.com
Password : 1234
```

**Admin panel:**

```
URL: https://localhost:5001/Security/Account/AdminLogin
Username : Admin
Password : 1234
```

## How it works

#### Admin Panel GUI Description:

1. Login admin panel with username and password.
2. Create resource type from `Resource Type` Menu.
3. Create resources based on `Resource Type` from `Resouce` Menu. When you create new resource, you have to click the IsMoveable checkbox for determine that resource moveable or not. Not moveable means that resource is Fixed resource.
4. Create Room based on office location from `Room` Menu. You have to input how many chair will be fixed in the room, which is not moveable .
5. Assign Fix resource( Not moveable resources) in the `Room` from `Assign Fixed Resource` Menu. This way system can understand which fix resources are available in the room.
6. `Admin` can see reservation list from `Reservations` menu. Which is already reserved by employees.
7. `Admin` can see ofice list from `Offices` menu.
8. `Admin` can see employee list from `Employees` menu.

#### User Panel GUI Description:

1. Log in panel with username and password.
2. For reservation search, user have to give the information like person, reservation date, start time , end time and click the search button from `Search Reservation` menu.
   Based on the given information and user's office location it will show all available rooms.
3. Click details button from the available room list, you will see fixed chair and fixed resources.
   You can choose your extra seat if you need any , also can choose moveable resources but only one moveable resource can choose from each type of resources.
4. After successfully resurvation you can see your all reservation from `Reserved` menu.
