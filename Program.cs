using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        CoffeeShop coffeeShop = new CoffeeShop();
        coffeeShop.Run();
    }
}

class CoffeeShop
{
    private List<MenuItem> menu;
    private List<MenuItem> order;
    private bool running;

    public CoffeeShop()
    {
        menu = new List<MenuItem>();
        order = new List<MenuItem>();
        running = true;
    }

    public void Run()
    {
        while (running)
        {
            ShowMainMenu();

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddItemToMenu();
                    break;
                case "2":
                    ViewMenu();
                    break;
                case "3":
                    PlaceOrder();
                    break;
                case "4":
                    ViewOrder();
                    break;
                case "5":
                    CalculateTotal();
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("\nCome Again Soon!");
                    break;
                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private void ShowMainMenu()
    {
        Console.WriteLine("~ ~ Welcome to the Coffee Shop! ~ ~\n");
        Console.WriteLine("1. Add Menu Item");
        Console.WriteLine("2. View Menu");
        Console.WriteLine("3. Place Order");
        Console.WriteLine("4. View Order");
        Console.WriteLine("5. Calculate Total");
        Console.WriteLine("6. Exit\n");
        Console.Write("Select an option: ");
    }

    private void AddItemToMenu()
    {
        Console.WriteLine();
        Console.Write("Enter item name: ");
        string item = Console.ReadLine();
        Console.Write("Enter item price: ");
        double price = Convert.ToDouble(Console.ReadLine());

        menu.Add(new MenuItem(item, price));
        Console.WriteLine("\nItem added successfully!\n- - - - - - - - - -");
    }

    private void ViewMenu()
    {
        if (menu.Count == 0)
        {
            Console.WriteLine("\nMenu is empty.\n- - - - - - - - - -");
            return;
        }

        Console.WriteLine("Menu:");
        for (int i = 0; i < menu.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {menu[i].Item} - ${menu[i].Price}");
        }
    }

    private void PlaceOrder()
    {
        if (menu.Count == 0)
        {
            Console.WriteLine("\nNo items in the menu to order from.\n- - - - - - - - - -");
            return;
        }

        ViewMenu();
        Console.WriteLine();
        Console.Write("Enter the item number to order: ");
        int itemNum = Convert.ToInt32(Console.ReadLine());

        if (itemNum > 0 && itemNum <= menu.Count)
        {
            order.Add(menu[itemNum - 1]);
            Console.WriteLine("\nItem added to order!\n- - - - - - - - - -");
        }
        else
        {
            Console.WriteLine("\nInvalid item number.");
        }
    }

    private void ViewOrder()
    {
        if (order.Count == 0)
        {
            Console.WriteLine("\nYour order is empty.\n- - - - - - - - - -");
            return;
        }

        Console.WriteLine("\nYour Order:");
        foreach (var item in order)
        {
            Console.WriteLine($"{item.Item} - ${item.Price}");
        }
    }

    private void CalculateTotal()
    {
        if (order.Count == 0)
        {
            Console.WriteLine("No items in the order to calculate.");
            return;
        }

        double total = 0;
        foreach (var item in order)
        {
            total += item.Price;
        }

        Console.WriteLine($"Total Amount Payable: ${total}");
    }
}

class MenuItem
{
    public string Item { get; set; }
    public double Price { get; set; }

    public MenuItem(string item, double price)
    {
        Item = item;
        Price = price;
    }
}
