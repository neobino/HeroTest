namespace Application.Models.HeroUpgrade
{
    public sealed class HeroUpgradePlan
    {
        public int LevelDelta { get; }
        public int StrengthDelta { get; }

        public HeroUpgradePlan(
            int levelDelta,
            int strengthDelta)
        {
            LevelDelta = levelDelta > 0 ? levelDelta : 0;
            StrengthDelta = strengthDelta > 0 ? strengthDelta : 0;
        }
    }
}