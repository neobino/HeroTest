using Cysharp.Threading.Tasks;
using Application.Models.HeroUpgrade;
using Application.Ports.HeroUpgrade;

namespace Application.UseCases.HeroUpgrade
{
    public sealed class GetHeroSnapshotUseCase : IGetHeroSnapshotUseCase
    {
        private readonly IHeroRepository _repo;

        public GetHeroSnapshotUseCase(IHeroRepository repo)
        {
            _repo = repo;
        }

        public UniTask<HeroSnapshot> ExecuteAsync()
        {
            var h = _repo.Get();
            var s = new HeroSnapshot(h.Name, h.Level, h.Strength);
            return UniTask.FromResult(s);
        }
    }
}