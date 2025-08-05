using System;
using R3;

namespace Game._Scripts.Presentation.Presenters
{
    public interface IHeroPresenter : IDisposable
    {
        ReactiveProperty<uint> Level { get; }
        ReactiveProperty<int> Attack { get; }
        void UpgradeHero();
    }
}