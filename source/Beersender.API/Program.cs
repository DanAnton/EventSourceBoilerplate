using Beersender.API.Event_stream;
using Beersender.API.JsonConverters;
using Beersender.API.Read_store;
using Beersender.API.ReadProjections;
using Beersender.Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddHostedService<EventPollingService>();

builder.Services.AddDbContext<ReadContext>(builder => builder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=Read_storage;Integrated Security=SSPI"));
builder.Services.AddDbContext<EventContext>(builder => builder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=Event_storage;Integrated Security=SSPI"));
builder.Services.AddTransient<Sql_event_store>();
builder.Services.AddTransient<Command_router>(services =>
{
    var store = services.GetService<Sql_event_store>();
    return new Command_router(id => store.Get_events(id), msg => store.Publish(msg.Aggregate_id, msg.Event));
});

builder.Services.AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.Converters.Add(new CommandConverter());
        opt.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    });
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
