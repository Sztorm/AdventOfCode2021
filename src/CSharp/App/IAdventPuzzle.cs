using System.Collections.Generic;

namespace AdventOfCode2021
{
    public interface IAdventPuzzle
    {
        AdventDay Day { get; }

        IEnumerable<string> GetResult(PuzzlePart part);
    }
}
