public class MatchParticipation {
    public int MatchParticipationId { get; set; }
    public DateOnly DatePlayed { get; set; }
    public string PlayerName { get; set; }
    public int PlayerId { get; set; }
    public int GoalScored { get; set; }
    public int MatchId { get; set; }
    public CardStatus Card { get; set; } = CardStatus.None;
}

public enum CardStatus{
    None,
    Red,
    Yellow
}