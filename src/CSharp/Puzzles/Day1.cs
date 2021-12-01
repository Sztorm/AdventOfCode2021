using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public class Day1 : IAdventPuzzle
    {
        public AdventDay Day => AdventDay.Day1;

        public IEnumerable<string> GetResult(PuzzlePart part) => part switch
        {
            PuzzlePart.Part1 => GetPart1Result(),
            PuzzlePart.Part2 => GetPart2Result(),
            _ => throw new ArgumentException("No result for specified part.", nameof(part)),
        };

        private IEnumerable<string> GetPart1Result()
            => throw new NotImplementedException();

        private IEnumerable<string> GetPart2Result()
            => throw new NotImplementedException();
    }
}
