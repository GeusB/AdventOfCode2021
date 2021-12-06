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
                else if (Math.Abs(ventRecord.XDelta) == Math.Abs(ventRecord.YDelta))
                {
                    for (var c = 0; c < Math.Abs(ventRecord.XDelta) + 1; c++)
                    {
                        if (ventRecord.Delta < 0)
                        {
                            if (grid[ventRecord.FromX + c, ventRecord.FromY - c] == 1)
                                count++;
                            grid[ventRecord.FromX + c, ventRecord.FromY - c]++;
                        }
                        else if (ventRecord.Delta > 0)
                        {
                            if (grid[ventRecord.FromX + c, ventRecord.FromY + c] == 1)
                                count++;
                            grid[ventRecord.FromX + c, ventRecord.FromY + c]++;
                        }
                    }
                }
            }
            return count;
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

        private static void Print(int[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[j, i] + "\t");
                }
                Console.WriteLine();
            }
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
            XDelta = X1 - X2;
            YDelta = Y1 - Y2;
            FromX = Math.Min(X1, X2);
            FromY = FromX == X1 ? Y1 : Y2;
            Delta = FromX == X1 ? Y2 - Y1 : Y1 - Y2;
        }

        public int X1 { get; }
        public int Y1 { get; }
        public int X2 { get; }
        public int Y2 { get; }
        public int XDelta { get; }
        public int YDelta { get; }
        public int FromX { get; }
        public int FromY { get; }
        public int Delta { get; }
    }
}