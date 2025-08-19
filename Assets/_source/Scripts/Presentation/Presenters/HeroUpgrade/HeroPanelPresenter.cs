using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer.Unity;
using Application.UseCases.HeroUpgrade;
using Application.Models.HeroUpgrade;
using Presentation.Views.HeroUpgrade;
using Presentation.ViewModels.HeroUpgrade;
using R3;

namespace Presentation.Presenters.HeroUpgrade
{
    public sealed class HeroPanelPresenter : IStartable, IDisposable
    {
        private readonly HeroViewModel _vm;
        private readonly IHeroUpgradeView _view;
        private readonly IUpgradeHeroUseCase _upgrade;
        private readonly IGetHeroSnapshotUseCase _get;

        private readonly CompositeDisposable _disposables = new();
        private readonly CancellationTokenSource _cts = new();

        private bool _busy;
        private readonly float _throttleFirst = 0.3f;

        public HeroPanelPresenter(
            HeroViewModel vm,
            IHeroUpgradeView view,
            IUpgradeHeroUseCase upgrade,
            IGetHeroSnapshotUseCase get)
        {
            _vm = vm;
            _view = view;
            _upgrade = upgrade;
            _get = get;
        }

        public void Start()
        {
            _vm.Name.Subscribe(_view.ShowName).AddTo(_disposables);
            _vm.Level.Subscribe(_view.ShowLevel).AddTo(_disposables);
            _vm.Strength.Subscribe(_view.ShowStrength).AddTo(_disposables);

            Observable.FromEvent<Action, Unit>(
                    h => () => h(Unit.Default),
                    h => _view.OnUpgradeClicked += h,
                    h => _view.OnUpgradeClicked -= h)
                .Where(_ => !_busy)
                .ThrottleFirst(TimeSpan.FromSeconds(_throttleFirst))
                .Subscribe(_ => UpgradeFlow().Forget())
                .AddTo(_disposables);

            Initialize().Forget();
        }

        private async UniTaskVoid Initialize()
        {
            try
            {
                _view.SetUpgradeInteractable(false);
                HeroSnapshot s = await _get.ExecuteAsync()
                    .AttachExternalCancellation(_cts.Token);
                _vm.Apply(s);
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception ex)
            {
                HandleError("Initialize failed", ex);
            }
            finally
            {
                _view.SetUpgradeInteractable(true);
            }
        }

        private async UniTaskVoid UpgradeFlow()
        {
            _busy = true;
            _view.SetUpgradeInteractable(false);
            try
            {
                UpgradeResult result = await _upgrade.ExecuteAsync()
                    .AttachExternalCancellation(_cts.Token);
                _vm.Apply(result.Snapshot);
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception ex)
            {
                HandleError("Upgrade failed", ex);
            }
            finally
            {
                _view.SetUpgradeInteractable(true);
                _busy = false;
            }
        }

        private void HandleError(string msg, Exception ex)
        {
            Debug.LogError($"[HeroUpgrade] {msg}: {ex}");
        }

        public void Dispose()
        {
            _cts.Cancel();
            _cts.Dispose();
            _disposables.Dispose();
        }
    }
}