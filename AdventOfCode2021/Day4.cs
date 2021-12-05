using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

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
            var result = GetData(fileLocation);
            var numbers = result.numbers;
            var cardDatas = result.cardList;
            var cards = cardDatas.Select(x => new Card(x)).ToList();
            
            foreach (var number in numbers)
            {
                var listToCheck = cards.Where(x=>x.CardScore == null).ToList();
                foreach (var card in listToCheck)
                {
                    if (number != null)
                    {
                        var cardResult = CheckCard(card, number.Value);
                        if (cardResult != null)
                        {
                            card.CardScore = cardResult * number;
                            if (listToCheck.Count == 1)
                                Console.WriteLine(card.CardScore);                   
                        }
                    }
                }
            }
        }

        private static (List<int?> numbers, List<List<int?[]>> cardList) GetData(string fileLocation)
        {
            using var reader = new StreamReader(fileLocation, Encoding.Default);
            var firstLine = reader.ReadLine();
            var numbers = firstLine.Split(',').Where(x => !string.IsNullOrEmpty(x)).Select(y => (int?) int.Parse(y))
                .ToList();
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
                        line.Split(' ').Where(x => !string.IsNullOrEmpty(x)).Select(y => (int?) int.Parse(y))
                            .ToArray());
            }

            cardList.Add(card);
            return (numbers, cardList);
        }


        private static void Part1(string fileLocation)
        {
            var result = GetData(fileLocation);
            var numbers = result.numbers;
            var cardDatas = result.cardList;
            var cards = cardDatas.Select(x => new Card(x)).ToList();
            int? winningResult = null;
            foreach (var number in numbers)
            {
                foreach (var card in cards)
                {
                    if (number != null)
                    {
                        winningResult = CheckCard(card, number.Value);
                        if (winningResult != null)
                            break;
                    }
                }

                if (winningResult != null)
                {
                    winningResult *= number;
                    break;
                }
            }

            Console.WriteLine(winningResult);
        }

        private static int? CheckCard(Card card, int number)
        {
            var cardData = card.CardData;
            for (var row = 0; row < cardData.Count; row++)
            {
                var rowData = cardData[row];
                for (var col = 0; col < rowData.Length; col++)
                {
                    var toCheck = rowData[col];
                    if (toCheck != number) continue;
                    cardData[row][col] = null;
                    card.Columns[col]++;
                    card.Rows[row]++;
                    if (HasWinningLine(card))
                    {
                        return GetCardScore(card);
                    }
                }
            }
            return null;
        }

        private static int GetCardScore(Card card)
        {
            return card.CardData.Sum(x => x.Sum(y => y ?? 0));
        }

        private static bool HasWinningLine(Card card)
        {
            return card.Columns.Any(x => x == 5) || card.Rows.Any(x => x == 5);
        }
    }

    public class Card
    {
        public Card(List<int?[]> card)
        {
            CardData = card;
            Columns = new[] {0, 0, 0, 0, 0};
            Rows = new[] {0, 0, 0, 0, 0};
            CardScore = null;
        }

        public List<int?[]> CardData { get; set; }
        public int[] Columns { get; set; }
        public int[] Rows { get; set; }
        
        public int? CardScore { get; set; }
    }
}