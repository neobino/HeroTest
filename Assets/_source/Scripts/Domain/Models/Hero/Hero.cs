using System;

namespace Domain.Models.Hero
{
    public sealed class Hero
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Strength { get; private set; }

        public Hero(string name = "Hero", int level = 1, int strength = 0)
        {
            Name = string.IsNullOrWhiteSpace(name) ? "New Hero" : name;
            Level = Math.Max(level, 1);
            Strength = Math.Max(strength, 0);
        }

        public void Rename(string newName)
        {
            if (!string.IsNullOrWhiteSpace(newName)) Name = newName;
        }

        public void LevelUp(int deltaLevels = 1)
        {
            if (deltaLevels > 0) Level = Level + deltaLevels;
        }

        public void AddStrength(int deltaStrength)
        {
            if (deltaStrength > 0) Strength = Strength + deltaStrength;
        }

        public void ApplyUpgrade(int levelDelta, int strengthDelta)
        {
            if (levelDelta > 0) Level = Level + levelDelta;
            if (strengthDelta > 0) Strength = Strength + strengthDelta;
        }
    }
}