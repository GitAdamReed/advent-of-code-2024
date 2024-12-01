using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Classes
{
    public class Day1 : Day
    {
        private static readonly string _inputPath = GetInputPath("Day1.txt");
        private static readonly string _outputPath = GetOutputPath("Day1.txt");
        
        public Day1()
        {
            CreateOutput();
        }

        private static List<int>[] ParseInput()
        {
            List<int> left = [];
            List<int> right = [];

            foreach (var line in File.ReadLines(_inputPath))
            {
                var splitLine = line.Split(' ');
                left.Add(Int32.Parse(splitLine.First()));
                right.Add(Int32.Parse(splitLine.Last()));
            }

            return [left, right];
        }
        
        private static int CalculateTotalDistance()
        {
            int sum = 0;
            List<int>[] nums = ParseInput();
            List<int> left = nums.First();
            List<int> right = nums.Last();

            left.Sort();
            right.Sort();
            
            for (int i = 0; i < left.Count; i++) sum += Int32.Abs(left[i] - right[i]);

            return sum;
        }
        
        protected override void CreateOutput()
        {
            File.WriteAllText(_outputPath, $"Part 1: {CalculateTotalDistance()}");
        }
    }
}
