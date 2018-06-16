using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityStarterProject.UI.OptionsMenu
{
    public class SoftParticleOptionManager : MenuOption
    {
        private string[] optionNames = new string[]
        {
            "Off",
            "On"
        };

        private void Awake()
        {
            dropdown.ClearOptions();

            dropdown.AddOptions(optionNames.ToList());

            Canvas.ForceUpdateCanvases();
        }

        public override void UpdateValues()
        {
            dropdown.value = QualityManager.Instance.GetSoftParticles() ? 1 : 0;
        }

        protected override void OptionChanged(int selection)
        {
            QualityManager.Instance.SetSoftParticles(selection == 0 ? false : true);
        }
    }
}