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
        {
            IEnumerable<int> measurements = IOUtils
                .ReadInput(Day)
                .Select(s => int.Parse(s));

            int prevMeasurement = measurements.First();
            int result = 0;

            foreach (int measurement in measurements.Skip(1))
            {
                if (measurement > prevMeasurement)
                {
                    result++;
                }
                prevMeasurement = measurement;
            }
            return new string[] { result.ToString() };
        }

        private IEnumerable<string> GetPart2Result()
        {
            IEnumerable<int> measurements = IOUtils
                .ReadInput(Day)
                .Select(s => int.Parse(s));

            var (m1, m2, m3) = measurements.FirstTriple();
            int result = 0;

            foreach (int measurement in measurements.Skip(3))
            {
                int prevTripleMeasurementSum = m1 + m2 + m3;
                int tripleMeasurementSum = m2 + m3 + measurement;

                if (tripleMeasurementSum > prevTripleMeasurementSum)
                {
                    result++;
                }
                (m1, m2, m3) = (m2, m3, measurement);
            }
            return new string[] { result.ToString() };
        }
    }
}
