using System;
using Game._Scripts.Domain.Models;
using Game._Scripts.Interfaces;
using MessagePipe;
using R3;
using VContainer;

namespace Game._Scripts.Presentation
{
    public class HeroPresenter : IHeroPresenter, IDisposable
    {
        private readonly IUpgradeHeroUseCase _upgradeHeroUseCase;
        private readonly IDisposable _subscription;

        public ReactiveProperty<int> HeroLevel { get; } = new();

        [Inject]
        public HeroPresenter(IUpgradeHeroUseCase upgradeHeroUseCase, ISubscriber<HeroModel> heroUpgradedSubscriber)
        {
            _upgradeHeroUseCase = upgradeHeroUseCase;
            _subscription = heroUpgradedSubscriber.Subscribe(model => HeroLevel.Value = model.Stats.Level);
        }

        public void UpgradeHero() => _upgradeHeroUseCase.Execute();

        public void Dispose()
        {
            _subscription?.Dispose();
            HeroLevel?.Dispose();
        }
    }
}