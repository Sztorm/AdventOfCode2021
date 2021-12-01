using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public static class PuzzleManager
    {
        public static void SolvePuzzle<T>(PuzzlePart part) where T : IAdventPuzzle, new()
        {
            var puzzle = new T();
            IEnumerable<string> result = puzzle.GetResult(part);

            foreach (string line in result)
            {
                Console.WriteLine(line);
            }
            IOUtils.WriteOutput(puzzle.Day, part, result);
        }
    }
}
