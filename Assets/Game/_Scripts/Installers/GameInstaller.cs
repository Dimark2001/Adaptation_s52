using Game._Scripts.Interfaces;
using Game._Scripts.Presentation;
using Game._Scripts.UseCases;
using MessagePipe;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;

namespace Game._Scripts.Installers
{
    public class GameInstaller : LifetimeScope
    {
        [SerializeField]
        private UIDocument _upgradeUIDocument;

        [SerializeField]
        private HeroConfig _heroConfig;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterMessagePipe();
            
            builder.RegisterInstance(_heroConfig);
            builder.Register(_ => _heroConfig.CreateModel(), Lifetime.Singleton);
            builder.Register<IUpgradeHeroUseCase, UpgradeHeroUseCase>(Lifetime.Singleton);
            builder.Register<IHeroPresenter, HeroPresenter>(Lifetime.Singleton);
            
            builder.RegisterInstance(_upgradeUIDocument);
            builder.RegisterComponentInHierarchy<HeroView>();
        }
    }
}