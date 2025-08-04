namespace Game._Scripts.Domain.Models
{
    public class HeroModel
    {
        public HeroStats Stats { get; private set; }

        public HeroModel(HeroStats heroStats)
        {
            Stats = heroStats;
        }

        public void Upgrade() => Stats.Upgrade();
    }
}