using UnityEngine;

namespace Infrastructure.Config.Hero
{
    [CreateAssetMenu(menuName = "Hero/Upgrade Recipe", fileName = "HeroUpgradeRecipe")]
    public sealed class HeroUpgradeSO : ScriptableObject
    {
        [SerializeField] [Min(1)] private int levelDelta = 1;

        [SerializeField] [Min(0)] private int strengthDelta = 5;

        [Min(1)] public int LevelDelta => levelDelta;
        [Min(0)] public int StrengthDelta => strengthDelta;
    }
}