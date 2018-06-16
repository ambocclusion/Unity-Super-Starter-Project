using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStarterProject.UI.OptionsMenu
{
    public class FullscreenOptionManager : MenuOption
    {
        private FullScreenMode[] modes;
        private List<string> fullScreenOptions = new List<string>();

        private void Awake()
        {
            modes = (FullScreenMode[])System.Enum.GetValues(typeof(FullScreenMode));

            dropdown.ClearOptions();

            foreach (FullScreenMode mode in modes)
            {
                string m = System.Text.RegularExpressions.Regex.Replace(mode.ToString(), "([a-z])([A-Z])", "$1 $2");
                fullScreenOptions.Add(m);
            }

            dropdown.AddOptions(fullScreenOptions);

            Canvas.ForceUpdateCanvases();
        }

        public override void UpdateValues()
        {
            FullScreenMode currentMode = Screen.fullScreenMode;

            for (int i = 0; i < modes.Length; i++)
            {
                if (modes[i] == currentMode)
                {
                    dropdown.value = i;
                }
            }
        }

        protected override void OptionChanged(int selection)
        {
            QualityManager.Instance.SetFullscreen(modes[selection]);
        }
    }
}