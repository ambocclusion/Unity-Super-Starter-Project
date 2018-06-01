using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStarterProject.UI.OptionsMenu
{
    public class ResolutionOptionManager : MonoBehaviour
    {
        public Dropdown dropdown;

        private void Awake()
        {
            Resolution currentResolution = QualityManager.Instance.GetCurrentResolution();

            Resolution[] resolutions = Screen.resolutions;
            List<string> resolutionOptions = new List<string>();

            dropdown.ClearOptions();

            foreach(Resolution res in resolutions)
            {
                resolutionOptions.Add(GetResolutionFormat(res));
            }

            if(resolutionOptions.Find(r => r == GetResolutionFormat(currentResolution)) == null)
            {
                resolutionOptions.Insert(0, GetResolutionFormat(currentResolution));
            }
            else
            {
                dropdown.value = resolutionOptions.IndexOf(GetResolutionFormat(currentResolution));
            }

            dropdown.AddOptions(resolutionOptions);

            dropdown.onValueChanged.AddListener(OptionChanged);
        }

        private string GetResolutionFormat(Resolution resolution)
        {
            return string.Format("{0} x {1} : {2}hz", resolution.width, resolution.height, resolution.refreshRate);
        }

        private void OptionChanged(int selection)
        {
            
        }
    }
}
