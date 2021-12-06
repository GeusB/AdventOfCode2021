using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AdventOfCode2021
{
    public static class Day5
    {
        public static void Execute()
        {
            var fileLocation = $"./Files/Day5.txt";

            Console.WriteLine(Part1(fileLocation));
            Console.WriteLine(Part2(fileLocation));
        }

        public static int Part2(string fileLocation)
        {
            return 0;
        }

        public static int Part1(string fileLocation)
        {
            var inputList = Tools.ReadListFromFile(MapRecord, fileLocation);
            var maxX = Math.Max(inputList.Max(x => x.X1), inputList.Max(x => x.X2));
            var maxY = Math.Max(inputList.Max(x => x.Y1), inputList.Max(x => x.Y2));
            var grid = new int[maxX + 1, maxY + 1];
            var count = 0;
            foreach (var ventRecord in inputList)
            {
                if (ventRecord.X1 == ventRecord.X2)
                {
                    var from = Math.Min(ventRecord.Y1, ventRecord.Y2);
                    var till = Math.Max(ventRecord.Y1, ventRecord.Y2);
                    for (var y = from; y <= till; y++)
                    {
                        if (grid[ventRecord.X1, y] == 1)
                            count++;
                        grid[ventRecord.X1, y]++;
                    }
                }
                else if (ventRecord.Y1 == ventRecord.Y2)
                {
                    var from = Math.Min(ventRecord.X1, ventRecord.X2);
                    var till = Math.Max(ventRecord.X1, ventRecord.X2);
                    for (var x = from; x <= till; x++)
                    {
                        if (grid[x, ventRecord.Y1] == 1)
                            count++;
                        grid[x, ventRecord.Y1]++;
                    }
                }
            }
            return count;
        }

        private static VentRecord MapRecord(string? line)
        {
            var points = line.Split("->").ToList();
            var values = points.SelectMany(x => x.Split(',')).Select(y => int.Parse(y)).ToArray();
            var record = new VentRecord(values);
            return record;
        }
    }

    public class VentRecord
    {
        public VentRecord(int[] values)
        {
            X1 = values[0];
            Y1 = values[1];
            X2 = values[2];
            Y2 = values[3];
        }

        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
    }
}