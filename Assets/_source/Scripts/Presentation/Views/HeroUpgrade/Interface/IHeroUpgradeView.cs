using System;

namespace Presentation.Views.HeroUpgrade
{
    public interface IHeroUpgradeView
    {
        void ShowName(string current);
        void ShowLevel(int current);
        void ShowStrength(int current);

        void SetUpgradeInteractable(bool value);
        
        event Action OnUpgradeClicked;
    }
}