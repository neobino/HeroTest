using UnityEngine;
using UnityEngine.Serialization;

namespace Infrastructure.Config.Hero
{
    [CreateAssetMenu(menuName = "Hero/Upgrade Recipe", fileName = "HeroUpgradeRecipe")]
    public sealed class HeroUpgradeSO : ScriptableObject
    {
        [SerializeField] 
        [Min(1)] private int _levelDelta = 1;

        [SerializeField] 
        [Min(0)] private int _strengthDelta = 5;

        [Min(1)] public int LevelDelta => _levelDelta;
        [Min(0)] public int StrengthDelta => _strengthDelta;
    }
}