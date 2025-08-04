using System;
using Game._Scripts.Application.UseCases;
using Game._Scripts.Domain.Models;
using MessagePipe;
using R3;
using VContainer;

namespace Game._Scripts.Presentation
{
    public class HeroPresenter : IHeroPresenter, IDisposable
    {
        private readonly IUpgradeHeroUseCase _upgradeHeroUseCase;
        private readonly IDisposable _subscription;

        public ReactiveProperty<uint> HeroLevel { get; } = new();
        public ReactiveProperty<int> HeroAttack { get; } = new();

        [Inject]
        public HeroPresenter(IUpgradeHeroUseCase upgradeHeroUseCase, ISubscriber<HeroModel> heroUpgradedSubscriber, HeroModel heroModel)
        {
            _upgradeHeroUseCase = upgradeHeroUseCase;
            _subscription = heroUpgradedSubscriber.Subscribe(model => HeroLevel.Value = model.Stats.Level);
            _subscription = heroUpgradedSubscriber.Subscribe(model => HeroAttack.Value = model.Stats.Attack);

            HeroLevel.Value = heroModel.Stats.Level;
        }

        public void UpgradeHero() => _upgradeHeroUseCase.Execute();

        public void Dispose()
        {
            _subscription?.Dispose();
            HeroLevel?.Dispose();
        }
    }
}