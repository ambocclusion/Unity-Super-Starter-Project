using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityStarterProject.UI.OptionsMenu
{
    public class TextureQualityOptionsManager : MenuOption
    {
        private string[] qualities = new string[]
        {
            "Low",
            "Medium",
            "High"
        };

        private void Awake()
        {
            dropdown.ClearOptions();

            dropdown.AddOptions(qualities.ToList());

            Canvas.ForceUpdateCanvases();
        }

        public override void UpdateValues()
        {
            dropdown.value = qualities.Length - 1 - QualityManager.Instance.GetTextureQuality();
        }

        protected override void OptionChanged(int selection)
        {
            QualityManager.Instance.SetTextureQuality(qualities.Length - 1 - selection);
        }
    }
}