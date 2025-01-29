using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Products
{
    public int Id { get; init; }
    public string Name { get; init; }
    public float Price { get; init; }

    public string Category { get; init; }

    public static float operator +(float total, Products pr) => total + pr.Price;
    public static float operator -(float total, Products pr) => total - pr.Price;
    public static bool operator true(Products pr) => pr.Price > 5;
    public static bool operator false(Products pr) => pr.Price <= 5;
    public override string ToString() => $"Id: {Id} - Name: {Name} - Price: {Price} - Category: {Category}";
}

