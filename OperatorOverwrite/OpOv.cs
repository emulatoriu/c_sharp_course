class OpVv
{
    public static void Main(string[] args)
    {
        ShoppingCart shoppingCart = new ShoppingCart();
        shoppingCart.add(new Products { Id = 1, Name = "Bananen", Category = "Fruits", Price = 2 });
        shoppingCart.add(new Products { Id = 2, Name = "Mangos", Category = "Fruits", Price = 4 });
        shoppingCart.add(new Products { Id = 3, Name = "Papaya", Category = "Fruits", Price = 5 });
        shoppingCart.add(new Products { Id = 4, Name = "Kiwi", Category = "Fruits", Price = 6 });
        shoppingCart.add(new Products { Id = 5, Name = "Himbeeren", Category = "Fruits", Price = 7 });

        //shoppingCart.remove(5);

        Console.WriteLine(shoppingCart.ToString());
        Console.WriteLine("----------------------------");
        Console.WriteLine("----------------------------");

        foreach(Products pr in shoppingCart.shopCart)
        {
            if(pr)
            {
                Console.WriteLine($"{pr.Name} ist sehr teuer.");
            }
            else
            {
                Console.WriteLine($"{pr.Name} ist nicht teuer.");
            }
        }
    }
}