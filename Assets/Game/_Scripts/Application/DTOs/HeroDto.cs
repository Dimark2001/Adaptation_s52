using Game._Scripts.Domain.Models;

namespace Game._Scripts.Application.DTO
{
    public struct HeroStatsDto
    {
        public uint Level { get; }
        public int Attack { get; }
        public bool IsMaxLevel { get; }

        public HeroStatsDto(IHeroStats stats)
        {
            Level = stats.Level;
            Attack = stats.Attack;
            IsMaxLevel = stats.Level >= stats.MaxLevel;
        }
    }
}