using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityStarterProject.UI.OptionsMenu
{
    public class ShadowResolutionOptionManager : MenuOption
    {
        private string[] optionNames = new string[]
        {
            "Low",
            "Medium",
            "High",
            "Very High"
        };

        private void Awake()
        {
            dropdown.ClearOptions();

            dropdown.AddOptions(optionNames.ToList());

            Canvas.ForceUpdateCanvases();
        }

        public override void UpdateValues()
        {
            dropdown.value = QualityManager.Instance.GetShadowResolution();
        }

        protected override void OptionChanged(int selection)
        {
            QualityManager.Instance.SetShadowResolution(selection);
        }
    }
}