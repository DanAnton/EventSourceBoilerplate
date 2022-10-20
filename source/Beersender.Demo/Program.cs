// See https://aka.ms/new-console-template for more information

using Beersender.Domain.Beer_packages;

var beer1 = new Beer_name("Gouden Carolus", "Quadrupel Whisky Infused");
var beer2 = new Beer_name("Gouden Carolus", "Quadrupel Whisky Infused");

if(ReferenceEquals(beer1, beer2))
    Console.WriteLine("Wait wut?");

Console.WriteLine(beer1);

var beer3 = beer1 with {Beer = "Classic"};
