// See https://aka.ms/new-console-template for more information

using Beersender.Domain;
using Beersender.Domain.Beer_packages;
using Beersender.Domain.Beer_packages.Commands;

var beer1 = new Beer_name("Gouden Carolus", "Quadrupel Whisky Infused");
var beer2 = new Beer_name("Gouden Carolus", "Quadrupel Whisky Infused");

if(ReferenceEquals(beer1, beer2))
    Console.WriteLine("Wait wut?");

Console.WriteLine(beer1);

var beer3 = beer1 with {Beer = "Classic"};
Console.WriteLine(beer3);



var events = new object[] { };
var publishedEvents = new List<object>();
var command_Router = new Command_router(_ => events, @event => publishedEvents.Add(@event));
var guid = Guid.NewGuid();
command_Router.Handle_command(new Create_package(guid));

command_Router.Handle_command(new Add_shipping_label(guid, new Shipping_label(Shipping_provider.UPS, "123456")));

var a = "";