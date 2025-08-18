using Cysharp.Threading.Tasks;
using Application.Models.HeroUpgrade;

namespace Application.UseCases.HeroUpgrade
{
    public interface IUpgradeHeroUseCase
    {
        UniTask<HeroSnapshot> ExecuteAsync();
    }
}