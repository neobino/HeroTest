using Application.Ports.HeroUpgrade;
using Application.UseCases.HeroUpgrade;
using Domain.Models.HeroUpgrade;
using Infrastructure.Config.Hero;
using Infrastructure.Persistence.HeroUpgrade;
using Infrastructure.Policies.HeroUpgrade;
using Presentation.Presenters.HeroUpgrade;
using Presentation.Views.HeroUpgrade;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Infrastructure.DI
{
    public class ProjectContextHeroUpgrade : LifetimeScope
    {
        [Header("Configs")] 
        [SerializeField] 
        private HeroInitialStatsSO _initialStats;

        [SerializeField] 
        private HeroUpgradeSO _upgradeRecipe;

        [Header("Views)]")]
        [SerializeField]
        private HeroView _heroView;

        [SerializeField] 
        private HeroPanelPresenter _heroPanelPresenter;


        protected override void Configure(IContainerBuilder builder)
        {
            RegisterConfig(builder);
            var hero = new Hero(
                _initialStats.Name,
                _initialStats.Level,
                _initialStats.Strength);


            builder.RegisterInstance(hero);

            RegisterPorts(builder);

            RegisterUseCase(builder);

            RegisterView(builder);
        }

        private void RegisterView(IContainerBuilder builder)
        {
            builder.RegisterComponent(_heroView);
            builder.RegisterComponent(_heroPanelPresenter);
        }

        private void RegisterUseCase(IContainerBuilder builder)
        {
            builder.Register<IUpgradeHeroUseCase, UpgradeHeroUseCase>(Lifetime.Singleton);
        }

        private void RegisterPorts(IContainerBuilder builder)
        {
            builder.Register<IHeroRepository, InMemoryHeroRepository>(Lifetime.Singleton);
            builder.Register<IHeroUpgrade, UpgradePolicyFromSO>(Lifetime.Singleton);
        }

        private void RegisterConfig(IContainerBuilder builder)
        {
            if (_initialStats == null)
                Debug.LogError("[DI] HeroInitialStatsSO is null");
            if (_upgradeRecipe == null)
                Debug.LogError("[DI] HeroUpgradeSO is null");

            builder.RegisterInstance(_initialStats);
            builder.RegisterInstance(_upgradeRecipe);
        }
    }
}
