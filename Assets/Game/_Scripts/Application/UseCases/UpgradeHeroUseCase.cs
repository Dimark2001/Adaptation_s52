using Game._Scripts.Application.DTO;
using Game._Scripts.Domain.Models;
using MessagePipe;
using VContainer;

namespace Game._Scripts.Application.UseCases
{
    public class UpgradeHeroUseCase : IUpgradeHeroUseCase
    {
        private readonly IHeroModel _heroModel;
        private readonly IPublisher<HeroStatsDto> _publisher;

        [Inject]
        public UpgradeHeroUseCase(IHeroModel heroModel, IPublisher<HeroStatsDto> publisher)
        {
            _heroModel = heroModel;
            _publisher = publisher;
        }

        public void Execute()
        {
            _heroModel.Upgrade();
            _publisher.Publish(new HeroStatsDto(_heroModel.Stats));
        }
    }
}