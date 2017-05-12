using System;
using System.Collections.Generic;
using EngNet;

namespace QuizNet {
  class Program {
    static void Main(string[] args) {
      Console.Write("Please, enter letters[апт]: ");

      string request = Console.ReadLine();

      DateTime start = DateTime.UtcNow;

      if (request.Length != 3) request = "апт";
      Console.WriteLine(request);
      Letters letters = new Letters(request);
      List<string> words = EngNet.EngNet.GetWords(letters);


      DateTime finish = DateTime.UtcNow;

      foreach (var w in words) {
        Console.WriteLine(w);
      }

      DateTime finishPrinting = DateTime.UtcNow;
      TimeSpan timeSpan = finish - start;
      TimeSpan timeSpanPrint = finishPrinting - finish;
      Console.WriteLine(letters.Query);
      Console.WriteLine($"Запрос выполнялся {timeSpan.TotalMilliseconds} миллисекунд.");
      Console.WriteLine($"Запрос выводился {timeSpanPrint.TotalMilliseconds} миллисекунд.");
      Console.WriteLine($"Всего подобрано слов: {words.Count}.");

      Console.ReadKey();
    }
  }
}
