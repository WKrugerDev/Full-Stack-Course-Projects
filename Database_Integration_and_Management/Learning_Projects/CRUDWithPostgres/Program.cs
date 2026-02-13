using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CRUDWithPostgres.Models;

class Program
{
    static void Main()
    {
        using var context = new ApplicationDbContext();

        //Create a new product
        var newProduct = new Product { Name = "Sample Product", Price = 9.99m };
        context.Products.Add(newProduct);
        context.SaveChanges();

        // Retrieve and display all products
        var products = context.Products.ToList();
        Console.WriteLine("Products in the database:");
        products.ForEach(product => Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}"));

        // Retrieve a product by ID
        var retrievedProduct = context.Products.Find(newProduct.Id);
        if (retrievedProduct != null)
        {
            Console.WriteLine($"Retrieved Product - ID: {retrievedProduct.Id}, Name: {retrievedProduct.Name}, Price: {retrievedProduct.Price}");
        }

        // Update a product
        var productToUpdate = context.Products.Find(newProduct.Id);
        if (productToUpdate != null)
        {
            productToUpdate.Price = 19.99m;
            context.SaveChanges();
            Console.WriteLine($"Updated Product ID {productToUpdate.Id} with new price: {productToUpdate.Price}");
        }    
        
        // Delete a product
        var productToDelete = context.Products.Find(newProduct.Id);
        if (productToDelete != null)        {
            context.Products.Remove(productToDelete);
            context.SaveChanges();
            Console.WriteLine($"Deleted Product ID {productToDelete.Id}");
        }
    }    
}