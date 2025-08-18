using Domain.Models.HeroUpgrade;
using Application.Ports.HeroUpgrade;

namespace Infrastructure.Persistence.HeroUpgrade
{
    public sealed class InMemoryHeroRepository : IHeroRepository
    {
        private readonly Hero _hero;

        public InMemoryHeroRepository(Hero hero)
        {
            _hero = hero;
        }

        public Hero Get() => _hero;

        public void Save(Hero hero)
        {
            //для сохранения в будущем
        }
    }
}