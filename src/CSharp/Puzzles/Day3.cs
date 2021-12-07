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
        int halfInputLength = input.Length / 2;
        int inputLineLength = input[0].Length;
        Span<int> ones = stackalloc int[inputLineLength];

        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j < inputLineLength; j++)
            {
                ones[j] += 1 * (input[i][j] - '0');
            }
        }
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
        string[] input = IOUtils.ReadInput(Day);
        string[] o2Input = input;
        string[] co2Input = input;
        int index = 0;

        while (o2Input.Length > 1)
        {
            int zeroCount = o2Input.Count(s => s[index] == '0');
            int oneCount = o2Input.Length - zeroCount;
            char mostCommonChar = oneCount >= zeroCount ? '1' : '0';

            o2Input = o2Input.Where(s => s[index] == mostCommonChar).ToArray();
            index++;
        }
        index = 0;

        while (co2Input.Length > 1)
        {
            int zeroCount = co2Input.Count(s => s[index] == '0');
            int oneCount = co2Input.Length - zeroCount;
            char leastCommonChar = zeroCount <= oneCount ? '0' : '1';

            co2Input = co2Input.Where(s => s[index] == leastCommonChar).ToArray();
            index++;
        }
        int o2Rating = Convert.ToInt32(o2Input.First(), 2);
        int co2Rating = Convert.ToInt32(co2Input.First(), 2);
        int lifeSupportRating = o2Rating * co2Rating;

        return new string[] { lifeSupportRating.ToString() };
    }
}