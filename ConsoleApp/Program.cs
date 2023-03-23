// See https://aka.ms/new-console-template for more information
using ConsoleApp.Services;

Console.WriteLine("Hello, World!");
StatusService statusService = new StatusService();
await statusService.InitializeAsync();