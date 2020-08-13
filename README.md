# EFCodeFirstApproach
ENTITY FRAMEWORK CODE-FIRST APPROACH  IN MVC
In the code-first approach the Entity Framework creates database objects based on model classes that you create to represent application data.
THE CODE-FIRST APPROACH:
•	Is the most common approach implemented in ASP.NET MVC Framework.
•	Allows you to develop your application by coding model classes and properties and delegate the process of creating the database objects to the Entity Framework.
•	The code-first approach allows you to define your own model by creating custom classes.
•	Then, you can create database based on the models.
The DbContext class:
•	Is provided by the System.Data.Entity namespace of the ASP.NET MVC Framework.
•	Can be used to define the database context class after creating a model class.
•	Coordinates with Entity Framework and allows you to query and save the data in the database.
•	Uses the DbSet <T> type to define one or more properties where, T represents the type of an object that needs to be stored in the database.
