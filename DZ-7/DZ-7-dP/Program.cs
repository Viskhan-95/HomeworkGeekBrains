// Decompiled with JetBrains decompiler
// Type: DZ_7.Program
// Assembly: DZ-7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 96A8D597-6C81-403B-B6A6-A5CDBBB101C6
// Assembly location: C:\Users\Висхан\Desktop\homeworkGB\DZ-7\DZ-7\obj\Debug\netcoreapp3.1\DZ-7.dll

using System;

namespace DZ_7
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      Console.Write("Enter a number from 0 to 10: ");
      if (Console.ReadLine() == "5")
        Console.WriteLine("Well done, guessed!");
      else
        Console.WriteLine("Not well done, not guessed!");
    }
  }
}
