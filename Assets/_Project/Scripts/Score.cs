namespace KingOfMountain
{
    public struct Score
    {
        public readonly int CurrentValue;
        public readonly int BestValue;

        public Score(int currentValue, int bestValue)
        {
            CurrentValue = currentValue;
            BestValue = bestValue;
        }
    }
}