// See https://aka.ms/new-console-template for more information

using Beersender.Domain.Beer_package;

var beer1 = new Beer_name("Gouden Carolus", "Quadrupel Whisky Infused");
var beer2 = new Beer_name("Gouden Carolus", "Quadrupel Whisky Infused");

if(ReferenceEquals(beer1, beer2))
    Console.WriteLine("Wait wut?");

Console.WriteLine(beer1);

var beer3 = beer1 with {Beer = "Classic"};
Console.WriteLine(beer3);

var sl = new Shipping_label(Shipping_provider.DHL, "DHL-123");
var sl2 = new Shipping_label(Shipping_provider.FedEx, "FE-345");
Console.WriteLine(sl);
Console.WriteLine(sl.Is_valid());
Console.WriteLine(sl2);
Console.WriteLine(sl2.Is_valid());