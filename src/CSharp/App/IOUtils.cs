namespace AdventOfCode2021;

public static class IOUtils
{
    public static readonly string BaseProjectPath = Directory.GetParent(
        Directory.GetCurrentDirectory())!.Parent!.Parent!.Parent!.Parent!.FullName;

    public static string GetInputPath(AdventDay day)
        => Path.Combine(BaseProjectPath, "data", day.ToString(), "input.txt");

    public static string GetInputPath(AdventDay day, PuzzlePart part)
        => Path.Combine(BaseProjectPath, "data", day.ToString(), $"input-part{(int)part}.txt");

    public static string GetOutputPath(AdventDay day)
        => Path.Combine(BaseProjectPath, "data", day.ToString(), "output.txt");

    public static string GetOutputPath(AdventDay day, PuzzlePart part)
        => Path.Combine(BaseProjectPath, "data", day.ToString(), $"output-part{(int)part}.txt");

    public static string[] ReadInput(AdventDay day)
        => File.ReadAllLines(GetInputPath(day));

    public static string[] ReadInput(AdventDay day, PuzzlePart part)
        => File.ReadAllLines(GetInputPath(day, part));

    public static void WriteOutput(AdventDay day, IEnumerable<string> output)
        => File.WriteAllLines(GetOutputPath(day), output);

    public static void WriteOutput(AdventDay day, PuzzlePart part, IEnumerable<string> output)
        => File.WriteAllLines(GetOutputPath(day, part), output);
}