using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2021
{
    public static class Tools
    {
        public static List<T> ReadListFromFile<T>(Func<string?, T> func, string location)
        {
            var list = new List<T>();
            using var reader = new StreamReader(location, Encoding.Default);
            while (!reader.EndOfStream)
            {
                list.Add(func(reader.ReadLine()));
            }
            return list;
        }
    }
}