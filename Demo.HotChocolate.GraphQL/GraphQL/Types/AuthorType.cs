using Demo.Shared.Database;
using Demo.Shared.Entities;

namespace Demo.Weather.HotChocolate.GraphQL.GraphQL.Types
{
    public class AuthorType : ObjectType<Author>
    {
        protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
        {
            _ = descriptor.Field(a => a.Id);
            _ = descriptor.Field(a => a.Name);
            _ = descriptor.Field(a => a.Posts)
                .UseDbContext<BlogDbContext>()
                .Resolver(ctx =>
                    ctx.DbContext<BlogDbContext>()
                    .Posts.Where(p => p.AuthorId == ctx.Parent<Author>().Id)
                 );
        }
    }
}
