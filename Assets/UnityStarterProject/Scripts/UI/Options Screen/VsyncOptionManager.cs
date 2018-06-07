using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStarterProject.UI.OptionsMenu
{
    public class VsyncOptionManager : MenuOption
    {
        private string[] vSyncLevels = new string[]
        {
            "Off",
            "Full",
            "Half V-Blank"
        };

        private void Awake()
        {
            dropdown.ClearOptions();

            dropdown.AddOptions(vSyncLevels.ToList());

            Canvas.ForceUpdateCanvases();
        }

        public override void UpdateValues()
        {
            dropdown.value = QualitySettings.vSyncCount;
        }

        protected override void OptionChanged(int selection)
        {
            QualityManager.Instance.SetVsync(selection);
        }
    }
}