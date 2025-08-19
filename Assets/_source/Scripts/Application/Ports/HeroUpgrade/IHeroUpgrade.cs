using Application.Models.HeroUpgrade;

namespace Application.Ports.HeroUpgrade
{
    using Domain.Models.HeroUpgrade;
    
    public interface IHeroUpgrade
    {
        HeroUpgradePlan CalculateUpgrade(Hero hero);
    }
}