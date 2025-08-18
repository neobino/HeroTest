using Application.Models.HeroUpgrade;
using Application.Ports.HeroUpgrade;
using Cysharp.Threading.Tasks;

namespace Application.UseCases.HeroUpgrade
{
    public class UpgradeHeroUseCase : IUpgradeHeroUseCase
    {
        private readonly IHeroRepository _repository;
        private readonly IHeroUpgrade _upgrade;

        public UpgradeHeroUseCase(IHeroRepository repository, IHeroUpgrade upgrade)
        {
            _repository = repository;
            _upgrade = upgrade;
        }

        public UniTask<HeroSnapshot> ExecuteAsync()
        {
            var hero = _repository.Get();
            var upgrade = _upgrade.CalculateUpgrade(hero);

            if (upgrade != null)
            {
                hero.ApplyUpgrade(upgrade.LevelDelta, upgrade.StrengthDelta);
                _repository.Save(hero);
            }

            var snapshot = new HeroSnapshot(hero.Name, hero.Level, hero.Strength);
            return UniTask.FromResult(snapshot);
        }
    }
}