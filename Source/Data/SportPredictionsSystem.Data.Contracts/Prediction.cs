﻿namespace SportPredictionsSystem.Data.Contracts
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Prediction : DeletableEntity, IPredictable
    {
        public DateTime MatchTime { get; set; }

        [Range(0, int.MaxValue)]
        public decimal Odd { get; set; }
    }
}