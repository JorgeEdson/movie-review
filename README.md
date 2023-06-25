# MovieReview
This project uses some of the most used technologies of the .net platform.
The project is organized based on **Onion Architecture** making the Domain centralized and independent. The Application Domain consists of an API that maintains reviews about movies and series, the application does not consume any other external API making the persistence of its own data.

## MovieReview.Core (Class Library)
- Provides the application's Domain Classes.
- Applies Object Orientation concepts such as access modifiers, inheritance.
- Provides DTO (Data Transfer Object) type classes that travel between the layers of the project.

## MovieReview.DataBase (Class Library)
- Provides data persistence using ORM **Entity Framework** and **SQL SERVER** Database
- With the **Code First** approach, this library uses the **Migrations** technique to create database tables from Domain Classes using **Fluent Mapping**
- Uses **AutoMapper** to convert Domain Classes to DTO Classes
- The pattern **Repository** is implemented to organize operations on the database.
- In this library are implemented the **Services** that concentrate the business rules and validations
- Uses cryptography for some data not to be exposed in the database

## MovieReview.API (ASP.NET CORE Web API)
- Authentication using **JWT Bearer** and **ApiKey**
- Uses **AutoMapper** to convert Domain Classes to DTO Classes
- endpoint versioning
- Documentation using Swagger
- Dependency Injection
