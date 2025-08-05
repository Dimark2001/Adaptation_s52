namespace Game._Scripts.Domain.Models
{
    public interface IHeroModel
    {
        IHeroStats Stats { get; }
        void Upgrade();
    }
}