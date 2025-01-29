using System;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string param = System.Configuration.ConfigurationManager.AppSettings.Get("age");

Console.WriteLine(SettingsTest.Settings.Default.test);
Console.WriteLine(param);
