﻿using GoNotifyMe;
using GoMarket;

Configuration configuration = new Configuration(@"../Configuration/config.toml");

configuration.ParseConfiguration();

ApiClient client = new ApiClient(configuration.Options!.Token!, null);

Console.WriteLine("Configuration Path");
Console.WriteLine(configuration.DefaultConfigurationPath);
Console.WriteLine(configuration.CurrentConfigurationPath);

Console.WriteLine("\nConfiguration Options");
Console.WriteLine($"Token: {configuration.Options?.Token}");
Console.WriteLine($"Target Email: {configuration.Options?.Target}");
Console.WriteLine($"Interval {configuration.Options?.FetchInterval}");
Console.WriteLine("\nEmail Configuration");
Console.WriteLine(configuration.Options?.Mail?.Email);
Console.WriteLine(configuration.Options?.Mail?.Password);
Console.WriteLine(configuration.Options?.Mail?.Server);
Console.WriteLine(configuration.Options?.Mail?.Port);

var productsFromAPI = client.GetProductList(32);
var variantsFromAPI = client.GetVariantList();

Console.WriteLine(productsFromAPI.Products?.Count);
Console.WriteLine(variantsFromAPI.Count);

Console.WriteLine(variantsFromAPI.Variants?[0].StockItems?[0].LocationName ?? $"No Name for Location of stock in {variantsFromAPI.Variants![0].Name}");

// I already know there is a product. So why should I check if there really is one?
var firstProduct = productsFromAPI.Products![0];

Console.WriteLine(firstProduct!.Id);
Console.WriteLine(firstProduct!.Name);
Console.WriteLine(firstProduct!.Price?.GetType());

var sameFirstProductButDifferentIGuessIdkThisIsATest = client.GetProduct(firstProduct!.Id);
Console.WriteLine(sameFirstProductButDifferentIGuessIdkThisIsATest.Id! == firstProduct.Id!);
Console.WriteLine(sameFirstProductButDifferentIGuessIdkThisIsATest.Id);
Console.WriteLine(sameFirstProductButDifferentIGuessIdkThisIsATest.Name);

// Can we get the image url now?
// I mean, it's unnecessary for this app, but I am making a full api client, soooooooooo
Console.WriteLine(firstProduct!.Variants![0].Images![0].SmallUrl);

// Now get the first variant through GetVariant
Console.WriteLine($"First Variant Price: {client.GetVariant(firstProduct.Variants![0].Id).Price}");

// Last thing before merging :D
var Categories = client.GetCategories();
var FirstCategory = Categories.First();

Console.WriteLine($"First Category on list: {FirstCategory.Name} (ID: {FirstCategory.Id})");

var a = Console.ReadLine();