
using System;
namespace library.Models

{
  public class Book
  {
    public string Name { get; }
    public bool CheckedOut { get; set; }
    public override string ToString()
    {
      return Name;
    }
    public Book(string name)
    {
      Name = name;
      CheckedOut = false;
    }

    public void CheckOut()
    {
      CheckedOut = true;
    }
    public void ReturnBook()
    {
      CheckedOut = false;
    }
  }
}