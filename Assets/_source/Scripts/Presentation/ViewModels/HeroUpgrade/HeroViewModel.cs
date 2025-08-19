using R3;
using Application.Models.HeroUpgrade;

namespace Presentation.ViewModels.HeroUpgrade
{
    public sealed class HeroViewModel
    {
        public ReactiveProperty<string> Name { get; } = new("");
        public ReactiveProperty<int> Level { get; } = new(1);
        public ReactiveProperty<int> Strength { get; } = new(0);

        public void Apply(HeroSnapshot s)
        {
            if (s == null) return;
            Name.Value = s.Name ?? "";
            Level.Value = s.Level;
            Strength.Value = s.Strength;
        }
    }
}