namespace Game._Scripts.Domain.Models
{
    public interface IHeroStats
    {
        uint Level { get; }
        int MaxLevel { get; }
        int Attack { get; }
        void Upgrade();
    }
}