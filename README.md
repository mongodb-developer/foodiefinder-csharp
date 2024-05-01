# Foodie Finder

This is a very basic demo .NET Console application, written using the new [MongoDB Provider for EF Core](https://github.com/mongodb/mongo-efcore-provider) that is now available in GA.

It gives examples of how to make use of some of the new features available in the GA release including:

* Support for embedded documents
* Use of Bson attributes such as [BsonElement("name")] and [BsonId]
* Value Converters
* Enhanced logging

## Running the application

You will need the following to run the application: 
* A MongoDB Atlas Cluster with the sample dataset loaded
* Your Connection String
* .NET 8

This app relies on .NET User Secrets so you will need to add the following to your ```secrets.json``` file:

``` "MongoDBAtlasConnectionString": "<YOUR CONNECTION STRING>"```

You can then start the application with

```bash
dotnet run
```

## Useful Resources

The following are some useful resources including tutorials and documentation:

* [Getting Started with CRUD in the new Provider in a Blazor Application](https://www.mongodb.com/developer/languages/csharp/crud-changetracking-mongodb-provider-for-efcore/)
* [MongoDB Provider for EF Core GitHub Repo including Roadmap](https://github.com/mongodb/mongo-efcore-provider)
* [Documentation](https://www.mongodb.com/docs/entity-framework/current/)
