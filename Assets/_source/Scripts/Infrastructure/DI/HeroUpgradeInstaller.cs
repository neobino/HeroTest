using Application.Ports.HeroUpgrade;
using Application.UseCases.HeroUpgrade;
using Domain.Models.HeroUpgrade;
using Infrastructure.Config.Hero;
using Infrastructure.Persistence.HeroUpgrade;
using Infrastructure.Policies.HeroUpgrade;
using Presentation.Presenters.HeroUpgrade;
using Presentation.ViewModels.HeroUpgrade;
using Presentation.Views.HeroUpgrade;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Infrastructure.DI
{
    public class HeroUpgradeInstaller : LifetimeScope
    {
        [Header("Configs")] 
        [SerializeField] 
        private HeroInitialStatsSO _initialStats;

        [SerializeField] 
        private HeroUpgradeSO _upgradeRecipe;

        [Header("Views)]")] 
        [SerializeField] 
        private HeroView _heroView;

        protected override void Configure(IContainerBuilder builder)
        {
            RegisterConfig(builder);
            RegisterPorts(builder);
            RegisterUseCase(builder);
            RegisterViewAndPresenter(builder);
        }
        

        private void RegisterViewAndPresenter(IContainerBuilder builder)
        {
            builder.Register<HeroViewModel>(Lifetime.Singleton);
            builder.RegisterComponent(_heroView);
            builder.RegisterEntryPoint<HeroPanelPresenter>();
        }

        private void RegisterUseCase(IContainerBuilder builder)
        {
            builder.Register<IUpgradeHeroUseCase, UpgradeHeroUseCase>(Lifetime.Singleton);
            builder.Register<IGetHeroSnapshotUseCase, GetHeroSnapshotUseCase>(Lifetime.Singleton);
        }

        private void RegisterPorts(IContainerBuilder builder)
        {
            builder.Register<IHeroRepository, InMemoryHeroRepository>(Lifetime.Singleton);
            builder.Register<IHeroUpgrade, UpgradePolicyFromSO>(Lifetime.Singleton);
        }

        private void RegisterConfig(IContainerBuilder builder)
        {
            if (_initialStats == null)
                Debug.LogWarning("[DI] HeroInitialStatsSO is null");
            if (_upgradeRecipe == null)
                Debug.LogError("[DI] HeroUpgradeSO is null");

            builder.RegisterInstance(_initialStats);
            builder.RegisterInstance(_upgradeRecipe);
        }
    }
}