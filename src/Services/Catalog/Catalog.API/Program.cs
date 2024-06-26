using Weasel.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions(); // There a 3 type's of session, this one is chosen for some purpose :)

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapCarter();

app.Run();