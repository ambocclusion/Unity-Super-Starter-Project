using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityStarterProject.UI.OptionsMenu
{
    public class AntialiasingOptionManager : MenuOption
    {
        private string[] aaLevels = new string[]
        {
            "Off",
            "FXAA",
            "SMAA",
            "TXAA"
        };

        private void Awake()
        {
            dropdown.ClearOptions();

            dropdown.AddOptions(aaLevels.ToList());

            Canvas.ForceUpdateCanvases();
        }

        public override void UpdateValues()
        {
            dropdown.value = (int)QualityManager.Instance.GetAntiAliasing();
        }

        protected override void OptionChanged(int selection)
        {
            QualityManager.Instance.SetAntiAliasing(selection);
        }
    }
}