using BuildingBlocks.Behaviors;

var builder = WebApplication.CreateBuilder(args);

// Add Services to the container
builder.Services.AddCarter();

var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});



var app = builder.Build();

// Configure the HTTP request pipeline
app.MapCarter();

app.Run();