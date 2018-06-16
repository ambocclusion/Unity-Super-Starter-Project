using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityStarterProject.UI.OptionsMenu
{
    public class ShadowModeOptionManager : MenuOption
    {
        private string[] optionNames = new string[]
        {
            "Shadowmask (Low)",
            "Distance Shadowmask (High)"
        };

        private void Awake()
        {
            dropdown.ClearOptions();

            dropdown.AddOptions(optionNames.ToList());

            Canvas.ForceUpdateCanvases();
        }

        public override void UpdateValues()
        {
            dropdown.value = QualityManager.Instance.GetShadowMaskMode();
        }

        protected override void OptionChanged(int selection)
        {
            QualityManager.Instance.SetShadowMaskMode(selection);
        }
    }
}