using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Classes
{
    public abstract class Day
    {
        protected static string GetInputPath(string textfile)
        {
            return "C:\\Users\\adamr\\Documents\\GitHub\\Advent_Of_Code\\advent-of-code-2024\\AdventOfCode2024\\AdventOfCode2024\\Input\\" + textfile;
        }
        protected static string GetOutputPath(string textfile)
        {
            return "C:\\Users\\adamr\\Documents\\GitHub\\Advent_Of_Code\\advent-of-code-2024\\AdventOfCode2024\\AdventOfCode2024\\Output\\" + textfile;
        }
        protected abstract void CreateOutput();
    }
}
