using System;
using System.IO;
using Xamarin.Essentials;

namespace DoctusTest.Data
{
    public class Constant
    {
        public const string DatabaseFilename = "DoctusSQLLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = FileSystem.AppDataDirectory;
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}
