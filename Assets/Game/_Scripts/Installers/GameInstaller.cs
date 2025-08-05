using Game._Scripts.Application.UseCases;
using Game._Scripts.Domain.Configs;
using Game._Scripts.Domain.Models;
using Game._Scripts.Presentation;
using Game._Scripts.Presentation.Presenters;
using Game._Scripts.Presentation.Views;
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

            builder.Register<IHeroModel>(_ => _heroConfig.CreateModel(), Lifetime.Singleton);
            builder.Register<IUpgradeHeroUseCase, UpgradeHeroUseCase>(Lifetime.Scoped);
            builder.Register<IHeroPresenter, HeroPresenter>(Lifetime.Scoped);

            builder.RegisterInstance(_upgradeUIDocument);
            builder.RegisterComponentInHierarchy<HeroView>();
        }
    }
}