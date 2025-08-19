using Cysharp.Threading.Tasks;
using Application.Models.HeroUpgrade;

namespace Application.UseCases.HeroUpgrade
{
    public interface IGetHeroSnapshotUseCase
    {
        UniTask<HeroSnapshot> ExecuteAsync();
    }
}