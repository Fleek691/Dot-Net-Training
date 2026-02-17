public class Team : IComparable<Team>
{
    public string Name { get; set; }
    public int Points { get; set; }

    public int CompareTo(Team other)
    {
        // Compare by points descending, then by name
        int pointsComparison = other.Points.CompareTo(this.Points);
        if (pointsComparison != 0)
            return pointsComparison;
        return this.Name.CompareTo(other.Name);
    }
}

public class Tournament
{
    private SortedList<int, Team> _rankings = new SortedList<int, Team>();
    private LinkedList<Match> _schedule = new LinkedList<Match>();
    private Stack<Match> _undoStack = new Stack<Match>();

    // Add match to schedule
    public void ScheduleMatch(Match match)
    {
        if (_schedule.Contains(match))
        {
            System.Console.WriteLine("Already Present");
            return;
        }
        _schedule.AddLast(match);
    }

    // Record match result and update rankings
    public void RecordMatchResult(Match match, int team1Score, int team2Score)
    {
        _undoStack.Push(match.Clone());

        match.Team1Score = team1Score;
        match.Team2Score = team2Score;

        // Update team points
        if (team1Score > team2Score)
        {
            match.Team1.Points += 3; // Win
        }
        else if (team2Score > team1Score)
        {
            match.Team2.Points += 3; // Win
        }
        else
        {
            match.Team1.Points += 1; // Draw
            match.Team2.Points += 1; // Draw
        }

        // Rebuild rankings
        _rankings.Clear();
        var allTeams = _schedule.SelectMany(m => new[] { m.Team1, m.Team2 }).Distinct().OrderBy(t => t).ToList();
        for (int i = 0; i < allTeams.Count; i++)
        {
            _rankings[i] = allTeams[i];
        }
    }

    // Undo last match
    public void UndoLastMatch()
    {
        if (_undoStack.Count == 0)
            return;

        Match previousMatch = _undoStack.Pop();

        // Find current match in schedule and revert scores
        var currentMatch = _schedule.FirstOrDefault(m =>
            m.Team1 == previousMatch.Team1 && m.Team2 == previousMatch.Team2);

        if (currentMatch != null)
        {
            // Revert points
            if (currentMatch.Team1Score > currentMatch.Team2Score)
            {
                currentMatch.Team1.Points -= 3;
            }
            else if (currentMatch.Team2Score > currentMatch.Team1Score)
            {
                currentMatch.Team2.Points -= 3;
            }
            else
            {
                currentMatch.Team1.Points -= 1;
                currentMatch.Team2.Points -= 1;
            }

            // Restore previous scores
            currentMatch.Team1Score = previousMatch.Team1Score;
            currentMatch.Team2Score = previousMatch.Team2Score;

            // Rebuild rankings
            _rankings.Clear();
            var allTeams = _schedule.SelectMany(m => new[] { m.Team1, m.Team2 }).Distinct().OrderBy(t => t).ToList();
            for (int i = 0; i < allTeams.Count; i++)
            {
                _rankings[i] = allTeams[i];
            }
        }
    }

    // Get ranking position using binary search
    public int GetTeamRanking(Team team)
    {
        for (int i = 0; i < _rankings.Count; i++)
        {
            if (_rankings[i] == team)
                return i + 1; // Return 1-based ranking
        }
        return -1; // Not found
    }
}

public class Match
{
    public Team Team1 { get; set; }
    public Team Team2 { get; set; }
    public int Team1Score { get; set; }
    public int Team2Score { get; set; }
    public DateTime MatchDate { get; set; }

    public Match Clone()
    {
        return new Match
        {
            Team1 = this.Team1,
            Team2 = this.Team2,
            Team1Score = this.Team1Score,
            Team2Score = this.Team2Score,
            MatchDate = this.MatchDate
        };
    }
}