using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Classes
{
    public class Day2 : Day
    {
        private static readonly string _inputPath = GetInputPath("Day2.txt");
        private static readonly string _outputPath = GetOutputPath("Day2.txt");

        public Day2()
        {
            CreateOutput();
        }

        private static List<List<int>> ParseInput()
        {
            List<List<int>> output = [];

            foreach (var line in File.ReadAllLines(_inputPath))
            {
                List<int> currentLevel = [];
                line.Split(' ').ToList().ForEach(x => currentLevel.Add(Int32.Parse(x)));
                output.Add(currentLevel);
            }

            return output;
        }

        private static int CalcNumOfSafeReports(bool problemDampening = false)
        {
            int unsafeCount = 0;
            var input = ParseInput();
            int k = 0;

            foreach (var list in input)
            {
                bool ascending = list[0] < list[1];
                if (k == 44 && problemDampening) 
                { 
                
                }
                
                for (int i = 0; i < list.Count - 1; i++)
                {
                    // Need to check elements follow ascending or descending order
                    // Need to check that element e[i] != e[i + 1]
                    // Need to check e[i] +/- e[i + 1] < 4
                    int diffCurrAndNext = list[i] - list[i + 1];
                    if (diffCurrAndNext >= 0 && ascending || diffCurrAndNext <= 0 && !ascending || Int32.Abs(diffCurrAndNext) > 3)
                    {
                        if (problemDampening && ProblemDampener(list, i, ascending))
                        {
                            break;
                        }
                        
                        unsafeCount++;
                        break;
                    }
                }

                k++;
            }

            return input.Count - unsafeCount;
        }

        private static bool ProblemDampener(List<int> list, int index, bool ascending)
        {
            if (index >= list.Count - 1) return false;

            int[] arrCopy = list.ToArray();
            //list.CopyTo(arrCopy);
            var listCopy0 = arrCopy.ToList();
            listCopy0.RemoveAt(index);
            bool problem = ProblemFinder(listCopy0, ascending);

            if (index + 1 < list.Count)
            {
                var listCopy1 = arrCopy.ToList();
                listCopy1.RemoveAt(index + 1);
                if (ProblemFinder(listCopy1, ascending)) return false;
                else return true;
            }

            if (index + 2 < list.Count)
            {
                var listCopy2 = arrCopy.ToList();
                listCopy2.RemoveAt(index + 2);
                if (ProblemFinder(listCopy2, ascending)) return false;
                else return true;
            }

            //int problemCount = 0;
            //for (int i = 2; i < list.Count; i++)
            //{
            //    bool zeroAndOne = Int32.Abs(list[i - 2] - list[i - 1]) > 3 || list[i - 2] > list[i - 1] && ascending || list[i - 2] < list[i - 1] && !ascending;
            //    bool oneAndTwo = Int32.Abs(list[i - 1] - list[i]) > 3 || list[i - 1] > list[i] && ascending || list[i - 1] < list[i] && !ascending;

            //    if (zeroAndOne && !oneAndTwo)
            //    {
            //        list.RemoveAt(i - 2);
            //        problemCount++;
            //    }
            //    else if (zeroAndOne && oneAndTwo)
            //    {
            //        list.RemoveAt(i - 1);
            //        problemCount++;
            //    }
            //    else if (!zeroAndOne && oneAndTwo)
            //    {
            //        list.RemoveAt(i);
            //        problemCount++;
            //    }

            //}

            //List<List<bool>> results = [];
            //var copy = list.ToArray();
            //list.RemoveAt(index);
            //var listCopy = copy.ToList();
            //listCopy.RemoveAt(index + 1);
            //List<List<int>> lists = [list, listCopy];

            //for (int i = 0; i < lists.Count; i++)
            //{
            //    List<bool> result = [];
            //    bool newAscending = lists[i][0] < lists[i][1];
            //    for (int j = 0; j < lists[i].Count - 1; j++)
            //    {
            //        int diff = Int32.Abs(lists[i][j] - lists[i][j + 1]);
            //        result.Add(diff > 0 && diff < 4 && lists[i][j] < lists[i][j + 1] && newAscending || lists[i][j] > lists[i][j + 1] && !newAscending);
            //    }
            //    results.Add(result);
            //}


            //if (results.All(r => r.Any(b => !b))) return false;


            //if (list.Count > index + 2)
            //{
            //    if (Int32.Abs(list[index + 1] - list[index + 2]) > 3 || list[index + 1] > list[index + 2] && ascending || list[index + 1] < list[index + 2] && !ascending)
            //    {
            //        newIndex++;
            //    }
            //}

            return !problem;
        }

        private static bool ProblemFinder(List<int> list, bool ascending)
        {
            bool problemFound = false;
            for (int i = 2; i < list.Count; i++)
            {
                bool zeroAndOne = Int32.Abs(list[i - 2] - list[i - 1]) > 3 || list[i - 2] > list[i - 1] && ascending || list[i - 2] < list[i - 1] && !ascending;
                bool oneAndTwo = Int32.Abs(list[i - 1] - list[i]) > 3 || list[i - 1] > list[i] && ascending || list[i - 1] < list[i] && !ascending;

                if (zeroAndOne || oneAndTwo)
                {
                    problemFound = true;
                    break;
                }
            }

            return problemFound;
        }

        protected override void CreateOutput()
        {
            File.WriteAllText(_outputPath, $"Part 1: {CalcNumOfSafeReports()}");
            File.AppendAllText(_outputPath, $"\nPart 2: {CalcNumOfSafeReports(problemDampening: true)}");
        }
    }
}
