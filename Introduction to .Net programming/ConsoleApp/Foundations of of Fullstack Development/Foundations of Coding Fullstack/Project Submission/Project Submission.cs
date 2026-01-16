using System;
using System.Collections.Generic;  // Needed for List<T>
					
public class Program
{
	static List<Product> products = new List<Product>();
	
    // Program class handles the main product management menu and operations such as 
    // viewing, adding, editing, and removing products from an in-memory list.
	public static void Main(String[] args)
	{
		bool exit = false;

        //Main menu loop: continues until the user chooses to exit
		while (!exit)
        {
            Console.WriteLine("\nProduct Management Menu:");
            Console.WriteLine("1. View Products");
            Console.WriteLine("2. Add Product");
            Console.WriteLine("3. Edit product stock levels");
            Console.WriteLine("4. Remove Product");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        ViewProducts();
                        break;
                    case 2:
                        AddProducts();
                        break;
                    case 3:
                        EditStock();
                        break;
					case 4:
						RemoveProducts();
						break;
                    case 5:
                        exit = true;
						Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Error: Invalid choice. Please enter 1-5.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Error: Please enter a valid number from the menu.");
            }
        }
	}

    //Displays all products currently in the list, or a message if the list is empty.
	static public void ViewProducts()
	{
        // Check if there are products to display
    	if(products.Count == 0)
        {
            Console.WriteLine("No products available.");
            return;
        }
        
        // Display product list
        Console.WriteLine("\n--- Product List ---");
        for(int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {products[i]}");
        }
        
	}

    // Prompts the user to add a new product with name, price, and stock.
    // Validates input and capitalizes product name.
	static public void AddProducts()
	{
		Console.Write("Enter product name: ");
        string name = Console.ReadLine()?.Trim();  // Read input and trim whitespace

        // Validate name
        if (string.IsNullOrEmpty(name)) 
        {
            Console.WriteLine("Error: Product name cannot be empty.");
            return;
        }

        // Capitalize first letter
        name = char.ToUpper(name[0]) + name.Substring(1);

        Console.Write("Enter product price: ");
        string input = Console.ReadLine()?.Trim().Replace('.', ','); // Replace '.' with ',' to handle decimal separator
        // Validate price
        if (!double.TryParse(input, out double price) || price <= 0)
        {
            Console.WriteLine("Error: Invalid price. Please enter a positive number.");
            return;
        }

        // Validate stock
        Console.Write("Enter stock amount: ");
        if (!int.TryParse(Console.ReadLine(), out int stock) || stock < 0)
        {
            Console.WriteLine("Error: Invalid stock amount. Please enter a non-negative integer.");
            return;
        }

        // Add product to list
        products.Add(new Product(name, price, stock));
        Console.WriteLine("✓ Product added successfully.");
	}

    //Allows editing of stock amounts for an existing product selected by number.
	static public void EditStock()
	{
		// Check if there are products to edit
        if (products.Count == 0)
        {
            Console.WriteLine("No products available to edit.");
            return;
        }

        // Display product list for selection
        Console.WriteLine("\n--- Product List ---");
        for(int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {products[i]}");
        }
        Console.Write("Enter the product number to edit stock: ");
        
        // Validate input and edit stock
        if (int.TryParse(Console.ReadLine(), out int productNumber) && productNumber > 0 && productNumber <= products.Count)
        {
            Product selectedProduct = products[productNumber - 1];
            Console.Write($"Current stock for '{selectedProduct.ProductName}' is {selectedProduct.StockAmount}. Enter new stock amount: ");
            if (int.TryParse(Console.ReadLine(), out int newStock) && newStock >= 0)
            {
                selectedProduct.StockAmount = newStock;
                Console.WriteLine("✓ Stock updated successfully.");
            }
            else
            {
                Console.WriteLine("Error: Invalid stock amount. Please enter a non-negative integer.");
            }
        }
        else
        {
            Console.WriteLine("Error: Invalid product number.");
        }
	}

    //Removes a selected product from the list.
	static public void RemoveProducts()
	{
        // Check if there are products to delete
        if (products.Count == 0)
        {
            Console.WriteLine("No products available to delete.");
            return;
        }

        // Display product list for selection
        Console.WriteLine("\n--- Product List ---");
        for(int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {products[i]}");
        }
        Console.Write("Enter the product number to delete: ");
        
        // Validate input and delete product
        if (int.TryParse(Console.ReadLine(), out int deleteNumber) && deleteNumber > 0 && deleteNumber <= products.Count)
        {
            string deletedProduct = products[deleteNumber - 1].ProductName;
            products.RemoveAt(deleteNumber - 1);
            Console.WriteLine($"✓ Product '{deletedProduct}' deleted.");
        }
        else
        {
            Console.WriteLine("Error: Invalid product number.");
        }  
	}


}

// Product class represents a single product with a name, price, and stock amount.
public class Product
{
    public string ProductName { get; set; }
	public double ProductPrice { get; set; }
	public int StockAmount { get; set; }

    //Constructor
	public Product(string productName, double productPrice, int stockAmount)
	{
		ProductName = productName;
		ProductPrice = productPrice;
		StockAmount = stockAmount;
	}

    //Override ToString for easy display (created so that each item in product list shows nicely)
	public override string ToString()
	{
		return $"Product Name: {ProductName}, Price: ${ProductPrice}, Stock: {StockAmount}";
	}

}