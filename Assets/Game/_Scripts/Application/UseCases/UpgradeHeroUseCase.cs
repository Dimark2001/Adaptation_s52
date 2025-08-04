using Game._Scripts.Domain.Models;
using MessagePipe;
using VContainer;

namespace Game._Scripts.Application.UseCases
{
    public class UpgradeHeroUseCase : IUpgradeHeroUseCase
    {
        private readonly HeroModel _heroModel;
        private readonly IPublisher<HeroModel> _heroUpgradedPublisher;

        [Inject]
        public UpgradeHeroUseCase(HeroModel heroModel, IPublisher<HeroModel> heroUpgradedPublisher)
        {
            _heroModel = heroModel;
            _heroUpgradedPublisher = heroUpgradedPublisher;
        }

        public void Execute()
        {
            _heroModel.Upgrade();
            _heroUpgradedPublisher.Publish(_heroModel);
        }
    }
}