namespace AdventOfCode2021;

public class Day2 : IAdventPuzzle
{
    public enum SubmarineMovementDirection
    {
        Forward,
        Down,
        Up,
    }

    public readonly record struct SubmarineMovement(int Depth, int HorizontalPosition)
    {
        public SubmarineMovement Moved(SubmarineMovementDirection direction, int steps)
            => direction switch
            {
                SubmarineMovementDirection.Forward => this with { 
                    HorizontalPosition = HorizontalPosition + steps },
                SubmarineMovementDirection.Down => this with { Depth = Depth + steps },
                SubmarineMovementDirection.Up => this with { Depth = Depth - steps },
                _ => throw new ArgumentException("Direction contains invalid value.")
            };
    }

    public AdventDay Day => AdventDay.Day2;

    public IEnumerable<string> GetResult(PuzzlePart part) => part switch
    {
        PuzzlePart.Part1 => GetPart1Result(),
        PuzzlePart.Part2 => GetPart2Result(),
        _ => throw new ArgumentException("No result for specified part.", nameof(part)),
    };

    private IEnumerable<string> GetPart1Result()
    {
        SubmarineMovement movement = IOUtils
            .ReadInput(Day)
            .Select(s =>
            {
                int stepsStartIndex = s.IndexOf(' ') + 1;
                ReadOnlySpan<char> directionText = s.AsSpan(start: 0, length: stepsStartIndex - 1);
                SubmarineMovementDirection direction = directionText.Equals("forward", StringComparison.Ordinal) 
                    ? SubmarineMovementDirection.Forward 
                    : directionText.Equals("down", StringComparison.Ordinal) 
                    ? SubmarineMovementDirection.Down 
                    : SubmarineMovementDirection.Up;
                int steps = int.Parse(s.AsSpan(stepsStartIndex, length: s.Length - stepsStartIndex));

                return (direction, steps);
            })
            .Aggregate(new SubmarineMovement(), (sm, ds) => sm.Moved(ds.direction, ds.steps));

        int result = movement.HorizontalPosition * movement.Depth;

        return new string[] { result.ToString() };
    }

    private IEnumerable<string> GetPart2Result()
    {
        throw new NotImplementedException();
    }
}