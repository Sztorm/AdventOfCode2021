namespace AdventOfCode2021;

public class Day3 : IAdventPuzzle
{
    public AdventDay Day => AdventDay.Day3;

    public IEnumerable<string> GetResult(PuzzlePart part) => part switch
    {
        PuzzlePart.Part1 => GetPart1Result(),
        PuzzlePart.Part2 => GetPart2Result(),
        _ => throw new ArgumentException("No result for specified part.", nameof(part)),
    };

    private IEnumerable<string> GetPart1Result()
    {
        string[] input = IOUtils.ReadInput(Day);
        int inputLineLength = input[0].Length;
        Span<int> ones = stackalloc int[inputLineLength];

        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j < inputLineLength; j++)
            {
                ones[j] += 1 * (input[i][j] - '0');
            }
        }
        int halfInputLength = input.Length / 2;
        uint gammaRate = 0U;
        uint epsilonRate = 0U;

        for (int i = 0; i < inputLineLength; i++)
        {
            uint mask = 1U << (inputLineLength - i - 1);
            gammaRate |= ones[i] >= halfInputLength ? mask : 0U;
            epsilonRate |= ones[i] < halfInputLength ? mask : 0U;
        }
        uint powerConsumption = gammaRate * epsilonRate;

        return new string[] { powerConsumption.ToString() };
    }

    private IEnumerable<string> GetPart2Result()
    {
        throw new NotImplementedException();
    }
}