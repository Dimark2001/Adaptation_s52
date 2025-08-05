using Game._Scripts.Application.UseCases;
using Game._Scripts.Application.DTO;
using Game._Scripts.Domain.Models;
using MessagePipe;
using R3;
using VContainer;

namespace Game._Scripts.Presentation.Presenters
{
    public class HeroPresenter : IHeroPresenter
    {
        private readonly IUpgradeHeroUseCase _upgradeUseCase;
        private readonly CompositeDisposable _disposables = new();

        public ReactiveProperty<uint> Level { get; } = new();
        public ReactiveProperty<int> Attack { get; } = new();

        [Inject]
        public HeroPresenter(IUpgradeHeroUseCase upgradeUseCase, ISubscriber<HeroStatsDto> statsSubscriber, IHeroModel  initialModel)
        {
            _upgradeUseCase = upgradeUseCase;
            UpdateStats(new HeroStatsDto(initialModel.Stats as HeroStats));

            statsSubscriber.Subscribe(UpdateStats).AddTo(_disposables);
        }

        private void UpdateStats(HeroStatsDto dto)
        {
            Level.Value = dto.Level;
            Attack.Value = dto.Attack;
        }

        public void UpgradeHero() => _upgradeUseCase.Execute();
        public void Dispose() => _disposables.Dispose();
    }
}