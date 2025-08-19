using UnityEngine;

namespace Infrastructure.Config.Hero
{
    [CreateAssetMenu(menuName = "Hero/Initial Stats", fileName = "HeroInitialStats")]
    public sealed class HeroInitialStatsSO : ScriptableObject
    {
        [SerializeField]
        private string _name = "Hero";
        
        [SerializeField]
        [Min(1)] private int _level = 1;
        
        [SerializeField]
        [Min(0)] private int _strength = 0;

        public string Name => _name;
        public int Level => _level;
        public int Strength => _strength;
    }
}