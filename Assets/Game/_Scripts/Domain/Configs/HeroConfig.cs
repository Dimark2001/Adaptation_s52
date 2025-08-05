using Game._Scripts.Domain.Models;
using UnityEngine;

namespace Game._Scripts.Domain.Configs
{
    [CreateAssetMenu(menuName = "Create HeroConfig", fileName = "HeroConfig", order = 0)]
    public class HeroConfig : ScriptableObject
    {
        [field: SerializeField]
        public HeroStats Model { get; private set; }

        public IHeroModel CreateModel() => new HeroModel((IHeroStats)Model.Clone());
    }
}