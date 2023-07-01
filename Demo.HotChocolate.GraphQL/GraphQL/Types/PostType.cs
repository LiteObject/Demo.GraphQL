using Demo.Shared.Database;
using Demo.Shared.Entities;

namespace Demo.Weather.HotChocolate.GraphQL.GraphQL.Types
{
    public class PostType : ObjectType<Post>
    {
        protected override void Configure(IObjectTypeDescriptor<Post> descriptor)
        {
            descriptor.Field(p => p.Id).Type<NonNullType<IntType>>();
            descriptor.Field(p => p.Title).Type<NonNullType<StringType>>();
            descriptor.Field(p => p.Content).Type<NonNullType<StringType>>();

            descriptor.Field(p => p.Author)
                .Type<NonNullType<AuthorType>>()
                .UseDbContext<BlogDbContext>()
                .Resolver(ctx =>
                    ctx.DbContext<BlogDbContext>()
                        .Find<Author>(ctx.Parent<Post>().AuthorId));

            descriptor.Field(p => p.Comments)
                .UseDbContext<BlogDbContext>()
                .Resolver(ctx =>
                    ctx.DbContext<BlogDbContext>()
                        .Comments.Where(c => c.PostId == ctx.Parent<Post>().Id));
        }
    }
}
