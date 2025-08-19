using Domain.Models.HeroUpgrade;
using Application.Ports.HeroUpgrade;
using Infrastructure.Config.Hero;

namespace Infrastructure.Persistence.HeroUpgrade
{
    public sealed class InMemoryHeroRepository : IHeroRepository
    {
        private readonly Hero _hero;
        
        public InMemoryHeroRepository(HeroInitialStatsSO initial)
        {
            var name = initial != null ? initial.Name : "Hero";
            var lvl  = initial != null ? initial.Level : 1;
            var str  = initial != null ? initial.Strength : 0;
            _hero = new Hero(name, lvl, str);
        }

        public Hero Get() => _hero;

        public void Save(Hero hero) { }
    }
}