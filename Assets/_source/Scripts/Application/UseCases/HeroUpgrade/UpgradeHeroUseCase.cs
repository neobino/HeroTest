using _source.Scripts.Application.Messages;
using Application.Models.HeroUpgrade;
using Application.Ports.HeroUpgrade;
using Cysharp.Threading.Tasks;
using MessagePipe;

namespace Application.UseCases.HeroUpgrade
{
    public class UpgradeHeroUseCase : IUpgradeHeroUseCase
    {
        private readonly IHeroRepository _repository;
        private readonly IHeroUpgrade _plan;
        private readonly IPublisher<HeroChanged> _publisher;

        public UpgradeHeroUseCase(IHeroRepository repository, IHeroUpgrade plan, IPublisher<HeroChanged> publisher)
        {
            _repository = repository;
            _plan = plan;
            _publisher = publisher;
        }

        public UniTask<UpgradeResult> ExecuteAsync()
        {
            var hero = _repository.Get();
            var plan = _plan.CalculateUpgrade(hero);

            if (plan == null)
            {
                var s = new HeroSnapshot(hero.Name, hero.Level, hero.Strength);
                return UniTask.FromResult(new UpgradeResult(false, s, "No upgrade available"));
            }

            hero.ApplyUpgrade(plan.LevelDelta, plan.StrengthDelta);
            _repository.Save(hero);
            
            var snapshot = new HeroSnapshot(hero.Name, hero.Level, hero.Strength);
            
            _publisher.Publish(new HeroChanged(snapshot));

            return UniTask.FromResult(new UpgradeResult(true, snapshot));
        }
    }
}