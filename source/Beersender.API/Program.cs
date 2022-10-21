using Beersender.API.EventStream;
using Beersender.API.JsonConverters;
using Beersender.API.Read_store;
using Beersender.API.ReadProjections;
using Beersender.Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddHostedService<EventPollingService>();
builder.Services.AddSingleton<EventRouter>();

builder.Services.AddSingleton<IProjection, PackageStatusUpdater>();

builder.Services.AddDbContext<ReadContext>(b =>
    b.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=Read_storage;Integrated Security=SSPI"));
builder.Services.AddDbContext<EventContext>(b =>
    b.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=Event_storage;Integrated Security=SSPI"));
builder.Services.AddTransient<SqlEventStore>();
builder.Services.AddTransient(services =>
{
    var store = services.GetService<SqlEventStore>();
    return new CommandRouter(id => store.GetEvents(id), msg => store.Publish(msg.AggregateId, msg.Event));
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