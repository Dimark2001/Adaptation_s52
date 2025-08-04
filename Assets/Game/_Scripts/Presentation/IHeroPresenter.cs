using R3;

namespace Game._Scripts.Presentation
{
    public interface IHeroPresenter
    {
        ReactiveProperty<uint> HeroLevel { get; }
        ReactiveProperty<int> HeroAttack { get; }
        void UpgradeHero();
    }
}