using System;
using UnityEngine;

namespace Game._Scripts.Domain.Models
{
    [Serializable]
    public class HeroStats : ICloneable
    {
        [field: SerializeField]
        public uint Level { get; private set; }

        [field: SerializeField]
        public int MaxLevel { get; private set; }

        [field: SerializeField]
        public int Attack { get; private set; }

        public void Upgrade()
        {
            if (Level >= MaxLevel)
            {
                return;
            }

            Level += 1;
            Attack += 10;
        }

        public object Clone()
        {
            return new HeroStats
            {
                Level = Level,
                MaxLevel = MaxLevel,
                Attack = Attack,
            };
        }
    }
}