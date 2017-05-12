using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;

namespace Engine {

  public static class Engine {
    private static string connectionString;
    private static FileInfo dbFile;

    static Engine() {
      dbFile = new FileInfo($"{AppContext.BaseDirectory}\\db.sqlite");
      connectionString = $"Data Source = {dbFile.FullName}";
    }

    public static List<string> GetWords(string letters) {
      List<string> result = GetWords(new Letters(letters));
      return result;
    }

    public static List<string> GetWords(char a, char b, char c) {
      List<string> result = GetWords(new Letters(a, b, c));
      return result;
    }

    public static List<string> GetWords(Letters l) {
      List<string> result = SelectFromDb(l);
      return result;
    }


    /// <summary>
    /// Лезем в базу за пододящими словами.
    /// </summary>
    /// <param name="letters">Буквы для поиска</param>
    /// <returns>Возвращаем лист строк с найденными словами.</returns>
    private static List<string> SelectFromDb(Letters letters) {
      List<string> result = new List<string>();
      SqliteConnection dbConnection = new SqliteConnection(connectionString);
      Console.WriteLine(connectionString);
      dbConnection.Open();
      SqliteCommand command = dbConnection.CreateCommand();
      command.CreateParameter();
      command.CommandText = $"Select * FROM words WHERE word like '{letters.SA}%{letters.SB}%{letters.SC}%'";
      letters.Query = command.CommandText;
      Console.WriteLine(command.CommandText);
      var tbl = command.ExecuteReader();
      while (tbl.Read()) {
        result.Add(tbl.GetString(0));
      }
      dbConnection.Close();
      return result;
    }
  }
}