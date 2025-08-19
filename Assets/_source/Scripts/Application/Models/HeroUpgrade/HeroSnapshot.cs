namespace Application.Models.HeroUpgrade
{
    public sealed class HeroSnapshot
    {
        public string Name { get; }
        public int Level { get; }
        public int Strength { get; }

        public HeroSnapshot(string name, int level, int strength)
        {
            Name = string.IsNullOrWhiteSpace(name) ? "Hero" : name;
            Level = level < 1 ? 1 : level;
            Strength = strength < 0 ? 0 : strength;
        }
    }
}