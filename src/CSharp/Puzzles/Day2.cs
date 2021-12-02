namespace AdventOfCode2021;

public class Day2 : IAdventPuzzle
{
    public enum SubmarineMovementDirection
    {
        Forward,
        Down,
        Up,
    }

    public readonly record struct SubmarineMovementV1(int Depth, int HorizontalPosition)
    {
        public SubmarineMovementV1 Moved(SubmarineMovementDirection direction, int steps)
            => direction switch
            {
                SubmarineMovementDirection.Forward => this with { 
                    HorizontalPosition = HorizontalPosition + steps },
                SubmarineMovementDirection.Down => this with { Depth = Depth + steps },
                SubmarineMovementDirection.Up => this with { Depth = Depth - steps },
                _ => throw new ArgumentException("Direction contains invalid value.")
            };
    }

    public readonly record struct SubmarineMovementV2(int Depth, int HorizontalPosition, int Aim)
    {
        public SubmarineMovementV2 Moved(SubmarineMovementDirection direction, int steps)
            => direction switch
            {
                SubmarineMovementDirection.Forward => this with
                {
                    HorizontalPosition = HorizontalPosition + steps,
                    Depth = Depth + Aim * steps,
                },
                SubmarineMovementDirection.Down => this with { Aim = Aim + steps },
                SubmarineMovementDirection.Up => this with { Aim = Aim - steps },
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

    private static (SubmarineMovementDirection Direction, int Steps) ParseInput(string s)
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
    }

    private IEnumerable<string> GetPart1Result()
    {
        SubmarineMovementV1 movement = IOUtils
            .ReadInput(Day)
            .Select(s => ParseInput(s))
            .Aggregate(new SubmarineMovementV1(), (sm, ds) => sm.Moved(ds.Direction, ds.Steps));

        int result = movement.HorizontalPosition * movement.Depth;

        return new string[] { result.ToString() };
    }

    private IEnumerable<string> GetPart2Result()
    {
        SubmarineMovementV2 movement = IOUtils
            .ReadInput(Day)
            .Select(s => ParseInput(s))
            .Aggregate(new SubmarineMovementV2(), (sm, ds) => sm.Moved(ds.Direction, ds.Steps));

        int result = movement.HorizontalPosition * movement.Depth;

        return new string[] { result.ToString() };
    }
}