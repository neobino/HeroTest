using UnityEngine;

namespace Hero.Infrastructure.Config
{
    [CreateAssetMenu(menuName = "Hero/Initial Stats", fileName = "HeroInitialStats")]
    public sealed class HeroInitialStatsSO : ScriptableObject
    {
        [SerializeField]
        private string name = "Hero";
        
        [SerializeField]
        [Min(1)] private int level = 1;
        
        [SerializeField]
        [Min(0)] private int strength = 0;

        public string Name => name;
        public int Level => level;
        public int Strength => strength;
    }
}