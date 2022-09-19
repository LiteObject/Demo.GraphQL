# Demo GraphQL with C#
> GraphQL is a query language for API, and a server-side runtime for executing queries using a type system define for data. GraphQL isn't tied to any specific database or storage engine and is instead backed by existing code and data.

![GraphQL logo](https://graphql.org/img/og-image.png)

>GraphQL is a new API standard that provides a more efficient, powerful, and flexible alternative to REST. It was developed and open sourced by Facebook and is now maintained by a large community of companies and individuals from all over the world.

![Example](https://graphql-engine-cdn.hasura.io/learn-hasura/assets/graphql-react/graphql-on-http.png)

At its core, GraphQL enables declarative data fetching where a client can specify exactly what data it needs from an API.

Instead of multiple endpoints that return fixed data structures, a GraphQL server only exposes a single endpoint and responds with precisely the data that a client asked for.

## Tools
- [Prisma](https://www.prisma.io/) creates tools and that replaces traditional ORMs. Prisma enriches the GraphQL ecosystem and community by creating high-quality tools and software.
- [Hasura](https://hasura.io/) is an open source engine that connects to your databases & microservices and auto-generates a production-ready GraphQL backend. Hasura gives you realtime GraphQL APIs that are high-performance, scalable, extensible & secure (with authorization baked in).

## GraphQL vs REST API

```
api/users/{id}
api/users/{id}/posts
api/users/{id}/followers
```

---
## There are two libraries to expose GraphQL endpoint:
- :trophy:[graphql-dotnet/graphql-dotnet](https://graphql-dotnet.github.io/docs/getting-started/introduction/)
- :star:[ChilliCream/hotchocolate](https://github.com/ChilliCream/hotchocolate/blob/main/website/src/docs/hotchocolate/get-started.md)
   - STEP #1: `dotnet add package HotChocolate.AspNetCore`
   - STEP #2: Define the types
   - STEP #3: Add a Query type
   - STEP #4: Add GraphQL services
     ```csharp
     builder.Services
        .AddGraphQLServer()
        .AddQueryType<Query>();
     ```
   - STEP #5: Map the GraphQL endpoint 
     ```csharp
     var app = builder.Build();
     // map GraphQL
     app.MapGraphQL();
     app.Run();
     ```

---
## Links:
- [The Fullstack Tutorial for GraphQL](https://www.howtographql.com/)
- [Code using GraphQL](https://graphql.org/code/#c-net)
- [Next-generation Node.js and TypeScript ORM](https://www.prisma.io/)
- [Hasura](https://hasura.io/)
- [github.com/graphql/graphql-playground](https://github.com/graphql/graphql-playground)
- [GraphQL for .NET](https://github.com/graphql-dotnet/graphql-dotnet)
- [ChilliCream/hotchocolate-examples](https://github.com/ChilliCream/hotchocolate-examples)
- [ChilliCream/graphql-workshop](https://github.com/ChilliCream/graphql-workshop)
