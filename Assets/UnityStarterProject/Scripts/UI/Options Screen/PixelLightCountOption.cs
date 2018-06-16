using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityStarterProject.UI.OptionsMenu
{
    public class PixelLightCountOption : MenuOption
    {
        public int[] qualities = new int[]
        {
            0,
            1,
            2,
            3
        };

        private string[] stringQualities = new string[0];

        private void Awake()
        {
            stringQualities = new string[qualities.Length];

            for (int i = 0; i < stringQualities.Length; i++)
            {
                stringQualities[i] = qualities[i].ToString();
            }

            dropdown.ClearOptions();

            dropdown.AddOptions(stringQualities.ToList());

            Canvas.ForceUpdateCanvases();
        }

        public override void UpdateValues()
        {
            int currentQuality = QualityManager.Instance.GetPixelLightCount();

            if (qualities.ToList().Contains(currentQuality))
            {
                dropdown.value = qualities.ToList().IndexOf(currentQuality);
            }
            else
            {
                dropdown.value = qualities.Length - 1;
            }
        }

        protected override void OptionChanged(int selection)
        {
            QualityManager.Instance.SetPixelLightCount(qualities[selection]);
        }
    }
}