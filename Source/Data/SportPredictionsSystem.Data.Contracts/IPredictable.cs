namespace SportPredictionsSystem.Data.Contracts
{
    using System;

    public interface IPredictable
    {
        DateTime MatchTime { get; set; }

        decimal Odd { get; set; }
    }
}
