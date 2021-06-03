# Vehicle Tracking Api

## Installing

#### Visual studio

Please make sure you've already installed Visual Studio 2019, .Net 5 sdk and Sql Server 2019 in your windows 10 platform .

[Visual Studio 2019](https://visualstudio.microsoft.com/downloads/)  
[.Net 5](https://dotnet.microsoft.com/download/dotnet/5.0)  
[Sql Server 2019](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

Select **VehicleTracking.sln** from `/VehicleTracking/` directory.
Change database connection in `appsettings.json` from `VehicleTracking.Api` project .

`ConnectionStrings` section in `appsettings.json`:

```
  "ConnectionStrings": {
    "VehicleTrackingConn": "Server=localhost;Database=VehicleTrackingDb;user id=sa;password=123456789;"
  },

```

Select and Run `VehicleTracking.Api` application.
I have implemented swagger documentation . You can see api documentation below url

```
Api documentation: https://localhost:5001/swagger/index.html
```

#### Docker

Make sure you have installed and configured docker in your environment. After that, you can run the below commands from the `/VehicleTracking/` directory and get started with the VehicleTracking immediately.

```powershell
docker-compose build
docker-compose up
```

You should be able to access api components of the application by using the below URLs :

```
Api: http://localhost:5100/
```

#### Local Kubernetes

Make sure you have installed and configured Kubernetes in your environment.
After that, you can run the below commands from the `/VehicleTracking/Kubernetes/` directory and get started with the VehicleTracking immediately.

```powershell
 ./build-images.ps1
 ./deploy-all.ps1
```

You should be able to access api components of the application by using the below URLs :

```
Api: http://localhost:5100/
```

## How it works

1. Register a client with first name , last name, email, password .
2. Client can login with email, password.

3. A registered client can add multiple vehicle with Name, DeviceId. DeviceId is unique id which you get from the GPS device.

4. GPS device send vehicle location with deviceId, latitude, longitude for the authentic client.

5. Authentic client can see their vehicle current location by vehicleId. Api will return longitude , latitude and address name. Google map api will return current address name based on the position.

6. Client can also see the vehicle journey by vehicleId, start and end datetime.

**Demo Login Credentials:**

URL: `https://localhost:5001/api/v1/Account/Login`

```
{
  "email": "ovibhuiyan43@gmail.com",
  "password": "1234"
}
```

## Extensibility

If customer wants add more properties than you should update Data Model.
After that have to do migration below commands.

```package manager
 add-migration "Added properties"
 update-database
```

## Bonus

I have implemented google map geocode which will send address based on latitude and longitude. You can find `GoogleApiService` .
