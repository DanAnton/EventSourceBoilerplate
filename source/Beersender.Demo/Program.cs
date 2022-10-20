using Beersender.Domain.BeerPackages;

var beer1 = new BeerName("Ursus", "Cooler");

Console.WriteLine(beer1);

var beer3 = beer1 with {Brewery = "Ciucas"};

Console.WriteLine(beer3);

Console.WriteLine(beer1 == new BeerName("Ursus", "Cooler"));
var shippingLabel = new ShippingLabel(ShippingProvider.UPS, "12346");
Console.WriteLine(shippingLabel);
Console.WriteLine(shippingLabel.IsValid());