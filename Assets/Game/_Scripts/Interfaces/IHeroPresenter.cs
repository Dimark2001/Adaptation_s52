using R3;

namespace Game._Scripts.Interfaces
{
    public interface IHeroPresenter
    {
        ReactiveProperty<int> HeroLevel { get; }
        void UpgradeHero();
    }
}