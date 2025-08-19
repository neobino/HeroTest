namespace Application.Ports.HeroUpgrade
{
    using Domain.Models.HeroUpgrade;
    
    public interface IHeroRepository
    {
        Hero Get();
        void Save(Hero hero);
    }
}