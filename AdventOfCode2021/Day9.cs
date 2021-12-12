using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

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
            var inputList = Tools.ReadListFromFile(MapRecord, fileLocation);
            var lowPointList = GetLowPointList(inputList);

            foreach (var lowPoint in lowPointList)
            {
                lowPoint.BasinSize = CalculateBasinSize(lowPoint, inputList);
            }

            var biggestThreeBasins = lowPointList.Select(x => x.BasinSize).OrderByDescending(x => x).Take(3);
            return biggestThreeBasins.Aggregate(1, (current, basinSize) => current * basinSize);
        }

        public static int Part1(string fileLocation)
        {
            var inputList = Tools.ReadListFromFile(MapRecord, fileLocation);
            var lowPointList = GetLowPointList(inputList);

            return lowPointList.Select(x => x.Depth + 1).Sum();
        }

        private static int CalculateBasinSize(LowPoint lowPoint, List<int[]> inputList)
        {
            var rowBasinSizeCount = 1;
            var rowArray = inputList[lowPoint.Row];
            for (var i = lowPoint.Col; i >= 0; i--)
            {
                if (i - 1 >= 0 && rowArray[i] < rowArray[i - 1] && rowArray[i - 1] < 9)
                {
                    rowBasinSizeCount++;
                }
                else
                    break;
            }

            var colCount = rowArray.Length;
            for (var i = lowPoint.Col; i <= colCount; i++)
            {
                if (i + 1 < colCount && rowArray[i] < rowArray[i + 1] && rowArray[i + 1] < 9)
                {
                    rowBasinSizeCount++;
                }
                else
                    break;
            }

            return rowBasinSizeCount;
        }

        private static List<LowPoint> GetLowPointList(List<int[]> inputList)
        {
            var lowPointList = new List<LowPoint>();
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
                        lowPointList.Add(new LowPoint(rowArray[col], row, col));
                    }
                }
            }

            return lowPointList;
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

    public class LowPoint
    {
        public LowPoint(int depth, int row, int col)
        {
            Depth = depth;
            Col = col;
            Row = row;
            BasinSize = 0;
        }

        public int Depth { get; }
        public int Col { get; }
        public int Row { get; }

        public int BasinSize { get; set; }
    }
}