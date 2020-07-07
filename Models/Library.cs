using System;
using System.Collections.Generic;
using library.Models;
using System.Threading;

namespace library.Models
{
  public class Library
  {
    List<Book> books = new List<Book>();
    private bool runing { get; set; }
    void ReturnBook()
    {
      List<Book> bookCheck = new List<Book>();
      bookCheck = books.FindAll(b => b.CheckedOut == true);
      if (bookCheck.Count <= 0)
      {
        Error.err("You dont have any books try checking one out first");
        return;
      }
      Console.Clear();
      Console.WriteLine("are you sure you want to return it... we could burn it...{y/n}");
      string input = Console.ReadLine();
      switch (input)
      {
        case "y":
        case "yes":
          BurnBook();
          return;
        case "n":
        case "no":
          break;
        default:
          Error.err();
          return;
      }
      Console.Clear();
      Console.WriteLine("witch book would you like to return");
      for (int i = 0; i < books.Count; i++)
      {
        if (books[i].CheckedOut)

          Console.WriteLine((i + 1) + ". " + books[i].ToString());

      }
      input = Console.ReadLine();

      int bookIndex;
      bool valid = Int32.TryParse(input, out bookIndex);
      if (valid)
      {
        bookIndex--;
        books[bookIndex].ReturnBook();
      }
      else
      {
        Error.err();
      }
    }
    void BurnBook()
    {
      Console.Clear();
      Console.WriteLine("witch book would you like to burn");
      for (int i = 0; i < books.Count; i++)
      {
        if (books[i].CheckedOut)

          Console.WriteLine((i + 1) + ". " + books[i].ToString());

      }
      string input = Console.ReadLine();
      int bookIndex;
      bool valid = Int32.TryParse(input, out bookIndex);
      if (valid)
      {
        bookIndex--;
        string bookName = books[bookIndex].Name;
        books.RemoveAt(bookIndex);
        Console.Clear();
        if (books.Count >= 6)
        {
          var cc = Console.ForegroundColor;
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine($"you monster.... {bookName} was my favorite book...");
          Console.ForegroundColor = cc;
        }
        else
        {
          var cc = Console.ForegroundColor;
          Console.ForegroundColor = ConsoleColor.Blue;
          Console.WriteLine("You already burned my favorite book. i dont care anymore");
          Console.ForegroundColor = cc;
        }
      }
      else
      {
        Error.err();
      }
    }
    public void viewBooks()
    {
      Console.Clear();
      Console.WriteLine("select a book to check out or quit...\n Books:");
      for (int i = 0; i < books.Count; i++)
      {
        if (!books[i].CheckedOut)
        {
          var cc = Console.ForegroundColor;
          Console.ForegroundColor = ConsoleColor.Green;
          Console.WriteLine((i + 1) + ". " + books[i].ToString());
          Console.ForegroundColor = cc;
        }
        else
        {
          var cc = Console.ForegroundColor;
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine((i + 1) + ". " + books[i].ToString() + " NOT AVALABLE");
          Console.ForegroundColor = cc;
        }
      }

      string input = Console.ReadLine();
      int bookIndex;
      bool valid = Int32.TryParse(input, out bookIndex);
      if (valid)
      {
        bookIndex--;
        if (!books[bookIndex].CheckedOut)
        {
          books[bookIndex].CheckOut();
          Console.Clear();
          Console.WriteLine("you checked out " + books[bookIndex].ToString());

        }
        else
        {
          Error.err();
        }

      }
      else
      {
        Error.err($"{input} is not a valid option");
      }
    }
    public Library()
    {
      Book book = new Book("null referance exception the sequel");
      books.Add(book);
      Book otherBook = new Book("all of the codes");
      book = otherBook;
      books.Add(book);
      books.Add(new Book("in the woods"));
      books.Add(new Book("everything"));
      books.Add(new Book("monty python "));
      books.Add(new Book("passion of the guy who did some stuff"));
      books.Add(new Book("not in the woods"));


      runing = true;
      Console.Clear();
      Console.WriteLine("Welcome to the library.\n what would you like to do?");

      LookAround();
    }
    void LookAround()
    {
      while (runing)
      {

        Console.WriteLine("look around {l} return a book{r} or quit {q}");
        string input = Console.ReadLine();
        switch (input)
        {
          case "q":
          case "quit":
            runing = false;
            break;
          case "l":
          case "look":
          case "look around":
            viewBooks();
            break;

          case "r":
          case "return":
            ReturnBook();
            break;
          default:
            Console.Clear();
            Error.err($"{input} is not a valid option");

            break;

        }
      }
    }
  }
}