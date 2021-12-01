using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2021
{
    public class Day1
    {
        
    }
    
    public static List<int> ReadList(string location)
    {
    var list = new List<int>();
        using var reader = new StreamReader(location, Encoding.Default);
        while (!reader.EndOfStream)
    {
        list.Add(int.Parse(reader.ReadLine() ?? string.Empty));
    }
    return list;
}
}