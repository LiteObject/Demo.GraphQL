using Demo.Shared.Database;
using Demo.Shared.Entities;

namespace Demo.Weather.HotChocolate.GraphQL.GraphQL.Types
{
    public class CommentType : ObjectType<Comment>
    {
        protected override void Configure(IObjectTypeDescriptor<Comment> descriptor)
        {
            descriptor.Field(c => c.Id).Type<NonNullType<IntType>>();
            descriptor.Field(c => c.Text).Type<NonNullType<StringType>>();
            descriptor.Field(c => c.Post).Type<NonNullType<PostType>>()
                .UseDbContext<BlogDbContext>()
                .Resolver(ctx =>
                    ctx.DbContext<BlogDbContext>()
                        .Find<Post>(ctx.Parent<Comment>().Id));
        }
    }
}
