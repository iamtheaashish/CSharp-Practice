// SaveScores(MakeDefaultScores());


List<Score> LoadHighScores()
{
    string[] scoreStrings = File.ReadAllLines("Scores.csv");
    List<Score> scores = new List<Score>();

    foreach (string scoreString in scoreStrings)
    {
        string[] tokens = scoreString.Split(",");
        Score score = new Score(tokens[0],Convert.ToInt32(tokens[1],Convert.ToInt32(tokens[2])));

        scores.Add(score);
    }
    return scores;
}

void SaveScores(List<Score> scores)
{
    List<string> scoreStrings = new List<string>();

    foreach (Score score in scores)
        scoreStrings.Add($"{score.Name},{score.Points},{score.Level}");

    File.WriteAllLines("Scores.csv", scoreStrings);
}

List<Score> MakeDefaultScores()
{
    return new List<Score>()
    {
        new Score("R2-D2", 12420, 15),
        new Score("C-3PO", 8543, 9),
        new Score("GONK", -1, 1)
    };
}

public record Score(string Name, int Points, int Level);
