using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
internal class ShoppingCart
{
    public List<Products> shopCart { get; init; } = new List<Products>();

    public float TotalPrice { get; set; }

    public void add(Products product)
    {
        shopCart.Add(product);
        TotalPrice += product;
    }

    public void remove(int id)
    {
        foreach(Products pr in shopCart)
        {
            if(pr.Id == id)
            {
                shopCart.Remove(pr);
                TotalPrice -= pr;
                break;
            }
        }
    }

    public override string ToString()
    {
        string shopCartContent =
            $"For your shopping tour you would have to spend currently {TotalPrice} Euro.";
        foreach(Products pr in shopCart)
        {
            shopCartContent += $"\n{pr.ToString()}";
        }
        return shopCartContent;
    }
    
    
}
