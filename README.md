# EasyManager ERP
The EasyManager is a free open source project that has the intent of creating a free ERP system using ASP.Net Core 2.1 since that are none at the moment.
The project was developed with micro services, CQRS and event sourcing in mind to be easily scalable

## How do I install it?
You can download the latest build at: https://github.com/fahelmoreira/EasyManagerERP/releases

And that's it!

## How do I start using it?
The first thing to do after download it is to run a ```dotnet restore``` and ```dotnet build``` inside of the WebAPI project folder than you need to should set the daba base configuration in the file ```appsettings.json``` inside the WebAPI and de Data Infrastructure projects.
The project uses Entity Framework and is current configured to use MS SQL Server data base if you wish to use a diferente data base you'll have to download the dependencies and manually configure it.
In the project folder you will find the SQL script to run in the database or you can run the ```dotnet ef database update``` to automatically create the database and the required tables.

The documentation can be found in the application accessing
```
https://localhost:5001/docs/
```

## Technologies used in this project
In order to create thi project was required the following technologies

```
ASP.Net 2.1.3
Entity Framework Core 2.1
MediatR
Swashbuckle,
FluentValidation

MS SQL Server for the data base
```

## I want to contribute!
That is great! Just clone the project in github. Create a topic branch, write some code, and add some tests for your new code.