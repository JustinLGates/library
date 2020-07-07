using System;
using System.Collections.Generic;
using library.Models;
using System.Threading;
namespace library.Models
{
  public abstract class Error
  {
    public static void err()
    {
      Console.Beep(1000, 100);
      Thread.Sleep(50);
      Console.Beep(890, 100);
      Console.Clear();
      var cc = Console.ForegroundColor;
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("Invalid input try again..");
      Console.ForegroundColor = cc;
    }
    public static void err(string Message)
    {
      Console.Beep(1000, 100);
      Thread.Sleep(50);
      Console.Beep(890, 100);
      Console.Clear();
      var cc = Console.ForegroundColor;
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine(Message);
      Console.ForegroundColor = cc;
    }
  }
}