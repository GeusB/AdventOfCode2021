using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2021
{
    public static class Day4
    {
        public static void Execute()
        {
            var day = nameof(Day4);
            var exampleLocation = $"./Files/{day}_ex.txt";
            var fileLocation = $"./Files/{day}.txt";

            Part1(exampleLocation);
            Part1(fileLocation);

            Part2(exampleLocation);
            Part2(fileLocation);
        }

        private static void Part2(string fileLocation)
        {
            var result = Data(fileLocation);
            var firstLine = result.numbers;
            var cards = result.cardList;
        }

        private static (List<int?> numbers, List<List<int?[]>> cardList) Data(string fileLocation)
        {
            using var reader = new StreamReader(fileLocation, Encoding.Default);
            var firstLine = reader.ReadLine();
            var numbers = firstLine.Split(' ').Where(x => !string.IsNullOrEmpty(x)).Select(y => (int?) int.Parse(y)).ToList();
            var cardList = new List<List<int?[]>>();
            var card = new List<int?[]>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line == string.Empty)
                {
                    if (card.Any())
                        cardList.Add(card);
                    card = new List<int?[]>();
                }
                else
                    card.Add(
                        line.Split(' ').Where(x => !string.IsNullOrEmpty(x)).Select(y => (int?) int.Parse(y)).ToArray());
            }

            cardList.Add(card);
            return (numbers, cardList);
        }


        private static void Part1(string fileLocation)
        {
        }
    }
}