using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddHttpContextAccessor()
    .AddGraphQLServer()
    .AddQueryType<Query>();

var app = builder.Build();

app.Use(async (context, next) =>
{
    var match = Regex.Match(context.Request.Path, @"\/world\/(.+?)/graphql");
    if (match.Success)
    {
        context.Items.Add("worldId", match.Groups[1].Value);
        context.Request.Path = "/graphql";
    }
    await next();
});

// need this for the middleware to rewrite the path
app.UseRouting();

app.MapGraphQL();

app.Run();
