using System;
using System.Collections.Generic;
using System.Linq;

// Simple console-based library manager.
// Refactored to use a List<string> and helper methods to improve readability,
// reduce repetition, and provide robust input validation and case-insensitive
// matching when adding/removing books.
class LibraryManager
{
	private const int MaxBooks = 5;
	// Maximum books a single user may borrow at once
	private const int MaxBorrowPerUser = 3;

	// Simple model for a book in the collection
		private class Book
		{
			public string Title { get; set; } = string.Empty;
			public bool IsBorrowed { get; set; }
		}

	static void Main()
	{
		var books = new List<Book>();

		while (true)
		{
			string action = Prompt("Choose an action: add / remove / borrow / checkin / search / exit")
				.ToLowerInvariant();

			switch (action)
			{
				case "add":
					HandleAdd(books);
					break;
				case "remove":
					HandleRemove(books);
					break;
				case "borrow":
					HandleBorrow(books);
					break;
				case "checkin":
					HandleCheckin(books);
					break;
				case "search":
					HandleSearch(books);
					break;
				case "exit":
					return;
				default:
					Console.WriteLine("Invalid action. Please type 'add', 'remove', 'borrow', 'checkin', 'search' or 'exit'.");
					break;
			}

			DisplayBooks(books);
			Console.WriteLine($"You have borrowed {books.Count(b => b.IsBorrowed)} book(s). (Limit: {MaxBorrowPerUser})");
		}
	}

	private static string Prompt(string message)
	{
		Console.WriteLine(message);
		return (Console.ReadLine() ?? string.Empty).Trim();
	}

	private static void HandleAdd(List<Book> books)
	{
		if (books.Count >= MaxBooks)
		{
			Console.WriteLine("The library is full. No more books can be added.");
			return;
		}

		string title = Prompt("Enter the title of the book to add:");
		if (string.IsNullOrWhiteSpace(title))
		{
			Console.WriteLine("Title cannot be empty.");
			return;
		}

		if (books.Any(b => string.Equals(b.Title, title, StringComparison.OrdinalIgnoreCase)))
		{
			Console.WriteLine("That book is already in the library.");
			return;
		}

		books.Add(new Book { Title = title, IsBorrowed = false });
		Console.WriteLine($"Added: {title}");
	}

	private static void HandleRemove(List<Book> books)
	{
		if (books.Count == 0)
		{
			Console.WriteLine("The library is empty. No books to remove.");
			return;
		}

		string title = Prompt("Enter the title of the book to remove:");
		if (string.IsNullOrWhiteSpace(title))
		{
			Console.WriteLine("Title cannot be empty.");
			return;
		}

		int idx = books.FindIndex(b => string.Equals(b.Title, title, StringComparison.OrdinalIgnoreCase));
		if (idx >= 0)
		{
			var removed = books[idx];
			books.RemoveAt(idx);
			Console.WriteLine($"Removed: {removed.Title}");
		}
		else
		{
			Console.WriteLine("Book not found.");
		}
	}

	// Borrow a book for the current user, up to MaxBorrowPerUser.
	private static void HandleBorrow(List<Book> books)
	{
		if (books.Count == 0)
		{
			Console.WriteLine("No books in the library to borrow.");
			return;
		}

		int borrowedCount = books.Count(b => b.IsBorrowed);
		if (borrowedCount >= MaxBorrowPerUser)
		{
			Console.WriteLine($"You have already borrowed {borrowedCount} books (limit {MaxBorrowPerUser}). Return a book before borrowing another.");
			return;
		}

		string title = Prompt("Enter the title of the book to borrow:");
		if (string.IsNullOrWhiteSpace(title))
		{
			Console.WriteLine("Title cannot be empty.");
			return;
		}

		var book = books.FirstOrDefault(b => string.Equals(b.Title, title, StringComparison.OrdinalIgnoreCase));
		if (book == null)
		{
			Console.WriteLine("That book is not in the collection.");
			return;
		}

		if (book.IsBorrowed)
		{
			Console.WriteLine("That book is currently checked out.");
			return;
		}

		book.IsBorrowed = true;
		Console.WriteLine($"You have borrowed: {book.Title}");
	}

	// Check-in a previously borrowed book.
	private static void HandleCheckin(List<Book> books)
	{
		if (books.Count == 0)
		{
			Console.WriteLine("No books in the library.");
			return;
		}

		string title = Prompt("Enter the title of the book to check in:");
		if (string.IsNullOrWhiteSpace(title))
		{
			Console.WriteLine("Title cannot be empty.");
			return;
		}

		var book = books.FirstOrDefault(b => string.Equals(b.Title, title, StringComparison.OrdinalIgnoreCase));
		if (book == null)
		{
			Console.WriteLine("That book is not in the collection.");
			return;
		}

		if (!book.IsBorrowed)
		{
			Console.WriteLine("That book is not currently checked out.");
			return;
		}

		book.IsBorrowed = false;
		Console.WriteLine($"Checked in: {book.Title}");
	}

	private static void HandleSearch(List<Book> books)
	{
		string title = Prompt("Enter the title of the book to search for:");
		if (string.IsNullOrWhiteSpace(title))
		{
			Console.WriteLine("Title cannot be empty.");
			return;
		}

		var book = books.FirstOrDefault(b => string.Equals(b.Title, title, StringComparison.OrdinalIgnoreCase));
		if (book == null)
		{
			Console.WriteLine("The book is not in the collection.");
		}
		else
		{
			Console.WriteLine(book.IsBorrowed ? "The book is currently checked out." : "The book is available.");
		}
	}

	private static void DisplayBooks(List<Book> books)
	{
		Console.WriteLine("Available books:");
		if (books.Count == 0)
		{
			Console.WriteLine("(none)");
			return;
		}

		for (int i = 0; i < books.Count; i++)
		{
			var b = books[i];
			string status = b.IsBorrowed ? "(checked out)" : "(available)";
			Console.WriteLine($"{i + 1}. {b.Title} {status}");
		}
	}
}