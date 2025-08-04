using Game._Scripts.Domain.Models;
using UnityEngine;

[CreateAssetMenu(menuName = "Create HeroConfig", fileName = "HeroConfig", order = 0)]
public class HeroConfig : ScriptableObject
{
    [field: SerializeField]
    public HeroStats Model { get; private set; }

    public HeroModel CreateModel() => new((HeroStats)Model.Clone());
}