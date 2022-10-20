// See https://aka.ms/new-console-template for more information

using Beersender.Domain.Commands.Models;

Shipping_label shipping_label1 = new(Shipping_provider.DHL, "DHL12345");
Shipping_label shipping_label2 = new(Shipping_provider.FedEx, "FED98765");

Console.WriteLine(shipping_label1);

var shipping_label3 = shipping_label1 with { Tracking_code = "XYZ56789" };
Console.WriteLine(shipping_label3);