using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStarterProject.UI.OptionsMenu
{
    public class ResolutionOptionManager : MenuOption
    {
        private Resolution[] resolutions;
        private List<string> resolutionOptions = new List<string>();

        private void Awake()
        {
            resolutions = Screen.resolutions;

            dropdown.ClearOptions();

            foreach (Resolution res in resolutions)
            {
                resolutionOptions.Add(GetResolutionFormat(res));
            }

            dropdown.AddOptions(resolutionOptions);

            Canvas.ForceUpdateCanvases();
        }

        public override void UpdateValues()
        {
            Resolution currentResolution = QualityManager.Instance.GetCurrentResolution();

            for (int i = 0; i < resolutions.Length; i++)
            {
                if (resolutions[i].height == currentResolution.height &&
                    resolutions[i].width == currentResolution.width &&
                    resolutions[i].refreshRate == currentResolution.refreshRate)
                {

                    dropdown.value = i;
                }
            }
        }

        protected override void OptionChanged(int selection)
        {
            QualityManager.Instance.SetResolution(resolutions[selection]);
        }

        private string GetResolutionFormat(Resolution resolution)
        {
            return string.Format("{0} x {1} : {2}hz", resolution.width, resolution.height, resolution.refreshRate);
        }
    }
}
