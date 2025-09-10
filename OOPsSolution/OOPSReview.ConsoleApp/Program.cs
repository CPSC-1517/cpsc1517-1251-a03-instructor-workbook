// See https://aka.ms/new-console-template for more information
using OOPsReview;

Console.WriteLine("Employment Demo");
//  Create a default instance of an Employement
//Employment employment1 = new Employment();
var employment1 = new Employment();
// Display all the properties of employment1
Console.WriteLine(employment1);

// Create a new Employment with specific values
var employment2 = new Employment("Software Deveoper 1",1,DateTime.Today, SupervisoryLevel.TeamMember);
Console.WriteLine(employment2);

// Display the Title of employment1
//Console.WriteLine($"Title: {employment1.Title}");
// Display the Years, StartDate, and Level
//Console.WriteLine($"Years: {employment1.Years}");
//Console.WriteLine($"Start Date: {employment1.StartDate.ToString("MMM d, yyyy")}");
//Console.WriteLine($"Level: {employment1.Level}");   