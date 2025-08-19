using Application.Models.HeroUpgrade;

namespace _source.Scripts.Application.Messages
{
    public class HeroChanged
    {
        public HeroSnapshot Snapshot { get; }

        public HeroChanged(HeroSnapshot snapshot)
        {
            Snapshot = snapshot;
        }
    }
}