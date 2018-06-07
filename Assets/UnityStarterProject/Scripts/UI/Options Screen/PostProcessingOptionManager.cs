using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityStarterProject.UI.OptionsMenu
{
    public class PostProcessingOptionManager : MenuOption
    {
        private string[] postNames = new string[]
        {
            "Off",
            "Low",
            "Medium",
            "High"
        };

        private void Awake()
        {
            dropdown.ClearOptions();

            dropdown.AddOptions(postNames.ToList());

            Canvas.ForceUpdateCanvases();
        }

        public override void UpdateValues()
        {
            dropdown.value = (int)QualityManager.Instance.GetPostProcessingQuality();
        }

        protected override void OptionChanged(int selection)
        {
            QualityManager.Instance.SetPostProcessingQuality(selection);
        }
    }
}