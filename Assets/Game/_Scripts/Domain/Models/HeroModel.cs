namespace Game._Scripts.Domain.Models
{
    public class HeroModel : IHeroModel
    {
        public IHeroStats Stats { get; private set; }

        public HeroModel(IHeroStats heroStats)
        {
            Stats = heroStats;
        }

        public void Upgrade() => Stats.Upgrade();
    }
}