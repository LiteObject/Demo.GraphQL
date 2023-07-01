using Demo.Weather.Shared.Database;
using Demo.Weather.Shared.Entities;

namespace Demo.Weather.HotChocolate.GraphQL.GraphQL.Types
{
    public class AuthorType : ObjectType<Author>
    {
        protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
        {
            descriptor.Field(a => a.Id).Type<NonNullType<IntType>>();
            descriptor.Field(a => a.Name).Type<NonNullType<StringType>>();
            descriptor.Field(a => a.Posts).Resolver(ctx =>
                ctx.Service<BlogDbContext>()
                    .Set<Post>()
                    .Where(p => p.AuthorId == ctx.Parent<Author>().Id));
        }
    }
}
