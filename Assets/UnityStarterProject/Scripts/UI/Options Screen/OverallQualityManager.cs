using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI; 

namespace UnityStarterProject.UI.OptionsMenu
{
    public class OverallQualityManager : MenuOption
    {
        private string[] names;

        private void Awake()
        {
            names = QualitySettings.names;

            dropdown.ClearOptions();

            dropdown.AddOptions(names.ToList());

            Canvas.ForceUpdateCanvases();
        }

        public override void UpdateValues()
        {
            dropdown.value = QualitySettings.GetQualityLevel();
        }

        protected override void OptionChanged(int selection)
        {
            QualityManager.Instance.SetQuality(selection);

            MenuOption[] options = transform.parent.GetComponentsInChildren<MenuOption>();

            foreach (MenuOption menu in options)
            {
                menu.UpdateValues();
            }
        }
    }
}
