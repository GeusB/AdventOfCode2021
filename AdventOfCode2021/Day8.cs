using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public static class Day8
    {
        public static void Execute()
        {
            var fileLocation = "./Files/Day8.txt";

            Console.WriteLine(Part1(fileLocation));
            Console.WriteLine(Part2(fileLocation));
        }

        public static int Part2(string fileLocation)
        {
            var inputList = Tools.ReadListFromFile(MapRecord, fileLocation);
            foreach (var signalRecord in inputList)
            {
                var zero = Array.Empty<char>();
                var one = Array.Empty<char>();
                var two = Array.Empty<char>();
                var three = Array.Empty<char>();
                var four = Array.Empty<char>();
                var five = Array.Empty<char>();
                var six = Array.Empty<char>();
                var seven = Array.Empty<char>();
                var eight = Array.Empty<char>();
                var nine = Array.Empty<char>();
                var fiveSegments = new List<char[]>();
                var sixSegments = new List<char[]>();

                foreach (var pattern in signalRecord.Patterns)
                {
                    var length = pattern.Length;
                    switch (length)
                    {
                        case 2:
                            one = pattern.ToCharArray();
                            break;
                        case 3:
                            seven = pattern.ToCharArray();
                            break;
                        case 4:
                            four = pattern.ToCharArray();
                            break;
                        case 7:
                            eight = pattern.ToCharArray();
                            break;
                        case 5:
                            fiveSegments.Add(pattern.ToCharArray());
                            break;
                        case 6:
                            sixSegments.Add(pattern.ToCharArray());
                            break;
                    }
                }

                foreach (var segment in sixSegments)
                {
                    if (!four.All(x => segment.Any(y => y == x))) continue;
                    nine = segment;
                    break;
                }

                foreach (var segment in sixSegments)
                {
                    if (nine.All(x => segment.Any(y => y == x)) || !one.All(x => segment.Any(y => y == x))) continue;
                    zero = segment;
                    break;
                }

                foreach (var segment in sixSegments)
                {
                    if (nine.All(x => segment.Any(y => y == x)) || zero.All(x => segment.Any(y => y == x))) continue;
                    six = segment;
                    break;
                }

                foreach (var segment in fiveSegments)
                {
                    if (!one.All(x => segment.Any(y => y == x))) continue;
                    three = segment;
                    break;
                }

                foreach (var segment in fiveSegments)
                {
                    if (six.Except(segment).Count() != 1) continue;
                    five = segment;
                    break;
                }

                foreach (var segment in fiveSegments)
                {
                    if (three == Array.Empty<char>() || two != Array.Empty<char>() ||
                        three.All(x => segment.Any(y => y == x)) || five.All(x => segment.Any(y => y == x))) continue;
                    two = segment;
                    break;
                }


                var stringDigits = "";
                foreach (var digit in signalRecord.Digits)
                    if (new HashSet<char>(one).SetEquals(digit))
                        stringDigits += "1";
                    else if (new HashSet<char>(two).SetEquals(digit))
                        stringDigits += "2";
                    else if (new HashSet<char>(three).SetEquals(digit))
                        stringDigits += "3";
                    else if (new HashSet<char>(four).SetEquals(digit))
                        stringDigits += "4";
                    else if (new HashSet<char>(five).SetEquals(digit))
                        stringDigits += "5";
                    else if (new HashSet<char>(six).SetEquals(digit))
                        stringDigits += "6";
                    else if (new HashSet<char>(seven).SetEquals(digit))
                        stringDigits += "7";
                    else if (new HashSet<char>(eight).SetEquals(digit))
                        stringDigits += "8";
                    else if (new HashSet<char>(nine).SetEquals(digit))
                        stringDigits += "9";
                    else if (new HashSet<char>(zero).SetEquals(digit))
                        stringDigits += "0";
                signalRecord.DecodedDigits = int.Parse(stringDigits);
            }

            return inputList.Sum(x => x.DecodedDigits);
        }

        public static int Part1(string fileLocation)
        {
            var inputList = Tools.ReadListFromFile(MapRecord, fileLocation);
            return inputList.Sum(signalRecord => signalRecord.Digits.Count(x => x.Length is 2 or 3 or 4 or 7));
        }

        private static SignalRecord MapRecord(string line)
        {
            return new SignalRecord(line);
        }
    }

    public class SignalRecord
    {
        public SignalRecord(string line)
        {
            var split = line.Split('|');
            Patterns = split.First().Trim().Split(' ');
            Digits = split.Last().Trim().Split(' ');
        }

        public string[] Patterns { get; }
        public string[] Digits { get; }
        public int DecodedDigits { get; set; }
    }
}