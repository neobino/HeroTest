namespace Application.Ports.Hero
{
    using Domain.Models.Hero;

    public interface IHeroRepository
    {
        Hero Get();
        void Save(Hero hero);
    }
}