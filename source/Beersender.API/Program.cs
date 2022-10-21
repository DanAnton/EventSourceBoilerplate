using Beersender.API.Event_stream;
using Beersender.API.JsonConverters;
using Beersender.Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EventContext>(builder => builder.UseSqlServer(@"Server=DK-ECI-JHH\SQLEXPRESS;Database=WorkshopRo;Trusted_Connection=True;"));
builder.Services.AddTransient<Command_router>(services =>
{
    var store = services.GetService<Sql_event_store>();
    return new Command_router(id => store.Get_events(id), msg => store.Publish(msg.Aggregate_id, msg.Event));
});

builder.Services.AddControllers()
    .AddJsonOptions(opt => opt.JsonSerializerOptions.Converters.Add(new CommandConverter()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
