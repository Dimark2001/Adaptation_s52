using System;
using UnityEngine;

namespace Game._Scripts.Domain.Models
{
    [Serializable]
    public class HeroStats : ICloneable
    {
        [field: SerializeField]
        public int Level { get; private set; }

        [field: SerializeField]
        public int MaxLevel { get; private set; }
        
        [field: SerializeField]
        public int Attack { get; private set; }

        public void Upgrade()
        {
            Level = Mathf.Clamp(Level + 1, 1, MaxLevel);
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