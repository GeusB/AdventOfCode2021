using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public static class Day9
    {
        public static void Execute()
        {
            var fileLocation = "./Files/Day９.txt";

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
            var lowPointList = new List<int>();
            for (var row = 0; row < inputList.Count; row++)
            {
                var rowArray = inputList[row];
                var colCount = rowArray.Length;
                for (var col = 0; col < colCount; col++)
                {
                    var isHorizontalMinValue = false;
                    if (col == 0 && rowArray[col] < rowArray[col + 1])
                    {
                        isHorizontalMinValue = true;
                    }
                    else if (col > 0 && col + 1 < colCount && rowArray[col] < rowArray[col - 1] &&
                             rowArray[col] < rowArray[col + 1])
                    {
                        isHorizontalMinValue = true;
                    }
                    else if (col > 0 && col + 1 == colCount && rowArray[col] < rowArray[col - 1])
                    {
                        isHorizontalMinValue = true;
                    }

                    if (!isHorizontalMinValue)
                        continue;

                    if (IsVerticalLowPoint(row, col, inputList))
                    {
                        lowPointList.Add(rowArray[col]);
                    }
                }
            }

            return lowPointList.Select(x => x + 1).Sum();
        }

        private static bool IsVerticalLowPoint(int row, int col, List<int[]> inputList)
        {
            var isVerticalMinValue = false;
            var potentialMinValue = inputList[row][col];
            var inputListCount = inputList.Count;
            if (row == 0 && potentialMinValue < inputList[row + 1][col])
            {
                isVerticalMinValue = true;
            }
            else
            {
                if (row > 0 && row + 1 < inputListCount && potentialMinValue < inputList[row - 1][col] &&
                    potentialMinValue < inputList[row + 1][col])
                {
                    isVerticalMinValue = true;
                }
                else if (row > 0 && row + 1 == inputListCount && potentialMinValue < inputList[row - 1][col])
                {
                    isVerticalMinValue = true;
                }
            }

            return isVerticalMinValue;
        }

        private static int[] MapRecord(string line)
        {
            return line.Trim().ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();
        }
    }
}