# Lab 1: Understanding ORM with a Retail Inventory System

## What is ORM?
ORM (Object-Relational Mapping) is a technique that maps C# classes to database tables. It lets developers work with objects instead of writing all SQL manually.

## Benefits of ORM
- Higher productivity
- Better maintainability
- Less direct SQL dependency

## EF Core vs EF Framework
- EF Core is cross-platform, lightweight, and supports modern features like LINQ, async queries, and compiled queries.
- EF Framework (EF6) is older, Windows-only, and less flexible than EF Core.

## EF Core 8.0 Features
- JSON column mapping
- Improved performance with compiled models
- Interceptors
- Better bulk operations

## Console App Setup
This lab uses a .NET Console App named `RetailInventory`.

## Packages Installed
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Design